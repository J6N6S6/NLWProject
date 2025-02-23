using TechLibrary.Application.Interfaces.Login.DoLogin;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;
using TechLibrary.Infrastructure.Data.Context.SQLite;
using TechLibrary.Infrastructure.Security.Criptography;
using TechLibrary.Infrastructure.Security.Tokens.Access;

namespace TechLibrary.Application.UseCases.Login.DoLogin
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestLoginJson request)
        {
            var dbContext = new TechLibraryDbContext();

            var entity = dbContext.Users.FirstOrDefault(u => u.Email.Equals(request.Email));

            if(entity is null)
                throw new InvalidLoginException();

            var cryptography = new BCryptAlgorithm();
            bool passwordIsValid = cryptography.Verify(request.Password, entity);

            if (passwordIsValid == false)
                throw new InvalidLoginException();

            var tokenGenerator = new JwtTokenGenerator();

            return new ResponseRegisteredUserJson()
            {
                Name = entity.Name,
                AccessToken = tokenGenerator.Generate(entity)
            };
        }
    }
}
