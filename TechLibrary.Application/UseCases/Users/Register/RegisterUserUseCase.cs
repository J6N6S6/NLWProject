using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Application.Interfaces.Users;
using TechLibrary.Exception;

namespace TechLibrary.Application.UseCases.Users.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase //Implemento a interface IRegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestUserJson request) //Recebo um RequestUserJson
        {
            Validate(request); //Chamo o método Validate passando o request

            return new ResponseRegisteredUserJson { };//Retorno um Json de ResponseRegisteredUserJson com Name e AccessToken
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
