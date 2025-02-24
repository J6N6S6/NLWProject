using Microsoft.Win32.SafeHandles;
using TechLibrary.Application.Interfaces.Checkouts;
using TechLibrary.Application.Interfaces.LoggedUser;
using TechLibrary.Exception;
using TechLibrary.Infrastructure.Data.Context.SQLite;
using TechLibrary.Infrastructure.Data.Domain.Entities;


namespace TechLibrary.Application.UseCases.Checkouts
{
    public class RegisterBookCheckoutUseCase : IRegisterBookCheckoutUseCase
    {
        private const int MAX_LOAN_DAYS = 7;
        private readonly ILoggedUser _loggedUser;

        public RegisterBookCheckoutUseCase(ILoggedUser loggedUser)
        {
            _loggedUser = loggedUser;
        }

        public void Execute(Guid bookId)
        {
            var dbContext = new TechLibraryDbContext();

            Validate(dbContext, bookId);

            var user = _loggedUser.GetUser();

            var entity = new Checkout
            {
                BookId = bookId,
                ExpectedReturnDate = DateTime.Now.AddDays(MAX_LOAN_DAYS),
                UserId = user.Id,
            };
            
            dbContext.Checkouts.Add(entity);

            dbContext.SaveChanges();

        }

        private void Validate(TechLibraryDbContext dbContext, Guid bookId)
        {
            var book = dbContext.Books.FirstOrDefault(b => b.Id == bookId);
            if (book is null)
                throw new NotFoundException("Book not found");

            var amountBookNotReturned = dbContext.Checkouts.Count(checkout => checkout.BookId == bookId && checkout.ReturnedDate == null);

            if (amountBookNotReturned >= book.Amount)
                throw new ConflitException("Book is not available to borrow");
        }
    }
}
