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
        public IActionResult DoLogin(RequestLoginJson request)
        {
            try
            {
                var response = _doLoginUseCase.Execute(request);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson { Errors = ["Unhandled exception" + ex.Message] });
            }
        }
    }
}