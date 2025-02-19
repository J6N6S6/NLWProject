using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Application.Interfaces.Users;

namespace TechLibrary.Application.UseCases.Users.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase //Implemento a interface IRegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute(RequestUserJson request) //Recebo um RequestUserJson
        {
            return new ResponseRegisteredUserJson { };//Retorno um Json de ResponseRegisteredUserJson com Name e AccessToken
        }

    }
}
