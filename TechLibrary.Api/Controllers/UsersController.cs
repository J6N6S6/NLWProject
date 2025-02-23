using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using TechLibrary.Application.Interfaces.Users;
using TechLibrary.Application.UseCases.Users.Register;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;
using TechLibrary.Exception;

namespace TechLibrary.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRegisterUserUseCase _registerUserUseCase;

        public UsersController(IRegisterUserUseCase registerUserUseCase)
        {
            _registerUserUseCase = registerUserUseCase;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)] //Retorno um ResponseRegisteredUserJson com status 201
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)] //Retorno um ResponseErrorMessagesJson com status 400
        public IActionResult Register(RequestUserJson request)
        {
            var response = _registerUserUseCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
