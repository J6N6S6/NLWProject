using TechLibrary.Application.Interfaces.Books;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Infrastructure.Data.Context.SQLite;
using TechLibrary.Infrastructure.Data.Domain.Entities;

namespace TechLibrary.Application.UseCases.Books
{
    public class FilterBooksUseCase : IFilterBooksUseCase
    {
        private const int PAGE_SIZE = 10;

        public ResponseBooksJson Execute(RequestFilterBooksJson request)
        {
            var dbContext = new TechLibraryDbContext();

            var query = dbContext.Books.AsQueryable();

            if (string.IsNullOrWhiteSpace(request.Title) == false)
            {
                query = query.Where(book => book.Title.Contains(request.Title));
            }

            var books = query.OrderBy(book => book.Title).ThenBy(book => book.Author)
                    .Skip((request.PageNumber - 1) * PAGE_SIZE) //Pulo os livros que já foram exibidos, se for a primeira página, não pula nada
                    .Take(PAGE_SIZE)
                    .ToList(); //Pego os próximos 10 livros

            int TotalCount = 0;

            if (string.IsNullOrWhiteSpace(request.Title))
                TotalCount = dbContext.Books.Count();
            else
                TotalCount = dbContext.Books.Where(b => b.Title.Contains(request.Title)).Count();



            return new ResponseBooksJson //Preencho o objeto de resposta com vários livros ResponseBookJson
            {
                Pagination = new ResponsePaginationJson
                {
                    PageNumber = request.PageNumber,
                    TotalCount = TotalCount,
                },
                Books = books.Select(book => new ResponseBookJson {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author
            }).ToList()
            };
        }
    }
}