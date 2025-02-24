using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechLibrary.Application.Interfaces.Checkouts;
using TechLibrary.Application.Interfaces.LoggedUser;
using TechLibrary.Application.UseCases.Checkouts;

namespace TechLibrary.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize] //Todos os endpoints deste controller precisam ser autorizados, aqui ele vai exigir o token
    public class CheckoutsController : ControllerBase
    {
        private readonly IRegisterBookCheckoutUseCase _registerBookCheckoutUseCase;
        private readonly ILoggedUser _loggedUser;

        public CheckoutsController(IRegisterBookCheckoutUseCase registerBookCheckoutUseCase, ILoggedUser loggedUser)
        {
            _registerBookCheckoutUseCase = registerBookCheckoutUseCase;
            _loggedUser = loggedUser;
        }

        [HttpPost]
        [Route("{bookId}")]
        public IActionResult BookCheckout(Guid bookId)
        {
            _registerBookCheckoutUseCase.Execute(bookId);

            return NoContent();
        }
    }
}
