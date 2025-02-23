using Microsoft.AspNetCore.Mvc;
using TechLibrary.Application.Interfaces.Login.DoLogin;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;

namespace TechLibrary.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IDoLoginUseCase _doLoginUseCase;
        public LoginController(IDoLoginUseCase doLoginUseCase)
        {
            _doLoginUseCase = doLoginUseCase;
        }

        [HttpPost] //Post para login para receber um RequestLoginJson
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)] //Retorno um ResponseRegisteredUserJson com status 201
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status500InternalServerError)] //Retorno um ResponseErrorMessagesJson com status 400
        public IActionResult DoLogin(RequestLoginJson request)
        {
            var response = _doLoginUseCase.Execute(request);
            return Ok(response);
        }
    }
}