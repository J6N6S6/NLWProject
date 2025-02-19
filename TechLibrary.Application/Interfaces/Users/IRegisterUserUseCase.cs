using TechLibrary.Communication.Responses;
using TechLibrary.Communication.Requests;

namespace TechLibrary.Application.Interfaces.Users
{
    public interface IRegisterUserUseCase
    {
        ResponseRegisteredUserJson Execute(RequestUserJson request);
    }
}
