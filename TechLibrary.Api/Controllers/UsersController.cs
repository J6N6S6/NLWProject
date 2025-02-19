using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using TechLibrary.Application.Interfaces.Users;
using TechLibrary.Application.UseCases.Users.Register;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;

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
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        public IActionResult Create(RequestUserJson request)
        {  
            ResponseRegisteredUserJson response = _registerUserUseCase.Execute(request);
            
            return Created(string.Empty, response);
        }
    }
}
