using TechLibrary.Application.Interfaces.Users;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;
using TechLibrary.Infrastructure.Data.Context.SQLite;
using TechLibrary.Infrastructure.Data.Domain.Entities;
using TechLibrary.Infrastructure.Security.Criptography;
using FluentValidation.Results;

namespace TechLibrary.Application.UseCases.Users.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase //Implemento a interface IRegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestUserJson request) //Recebo um RequestUserJson
        {
            var dbContext = new TechLibraryDbContext(); //Instancio um TechLibraryDbContext

            Validate(request, dbContext); //Chamo o método Validate passando o request

            var cryptography = new BCryptAlgorithm(); //Instancio um BCryptAlgorithm

            var entity = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = cryptography.HashPassword(request.Password), //Crio um novo usuário com Name, Email e Password criptografado
            };


            dbContext.Users.Add(entity); //Adiciono a entidade no contexto - cria um insert
            dbContext.SaveChanges(); //Salvo as alterações - executa o insert

            return new ResponseRegisteredUserJson {
                Name = entity.Name,
            };//Retorno um Json de ResponseRegisteredUserJson com Name e AccessToken
        }

        private void Validate(RequestUserJson request, TechLibraryDbContext dbContext)
        {
            var validator = new RegisterUserValidator(); //Instancio um RegisterUserValidator

            var result = validator.Validate(request); //Faço a validação do request

            var existsUserWithEmail = dbContext.Users.Any(u => u.Email.Equals(request.Email)); //Verifico se já existe um usuário com o email informado
            //Se eu uso u.Email == request.Email, eu estou comparando o email do usuário no banco de dados com o email informado no request
            //Se eu uso u.Email.Equals(request.Email), eu estou comparando o email do usuário no banco de dados com o email informado no request ignorando o case sensitive

            if(existsUserWithEmail)
                result.Errors.Add(new ValidationFailure("Email", "Email already exists")); //Adiciono um erro de validação

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList(); //Pego os erros de validação
                throw new ErrorOnValidationException(errorMessages); //Lanço uma exceção com as mensagens de erro
            }
        }
    }
}
