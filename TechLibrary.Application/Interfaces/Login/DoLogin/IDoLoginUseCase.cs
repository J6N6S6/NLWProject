using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;

namespace TechLibrary.Application.Interfaces.Login.DoLogin
{
    public interface IDoLoginUseCase
    {
        ResponseRegisteredUserJson Execute(RequestLoginJson request);
    }
}
