using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Application.Interfaces.Users;
using TechLibrary.Exception;
using TechLibrary.Infrastructure.Data.Domain.Entities;
using TechLibrary.Infrastructure.Data.Context.SQLite;

namespace TechLibrary.Application.UseCases.Users.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase //Implemento a interface IRegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestUserJson request) //Recebo um RequestUserJson
        {
            Validate(request); //Chamo o método Validate passando o request

            var entity = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password
            };

            var dbContext = new TechLibraryDbContext(); //Instancio um TechLibraryDbContext

            dbContext.Users.Add(entity); //Adiciono a entidade no contexto - cria um insert
            dbContext.SaveChanges(); //Salvo as alterações - executa o insert

            return new ResponseRegisteredUserJson {
                Name = entity.Name,
            };//Retorno um Json de ResponseRegisteredUserJson com Name e AccessToken
        }

        private void Validate(RequestUserJson request)
        {
            var validator = new RegisterUserValidator(); //Instancio um RegisterUserValidator
            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList(); //Pego os erros de validação
                throw new ErrorOnValidationException(errorMessages); //Lanço uma exceção com as mensagens de erro
            }
        }
    }
}
