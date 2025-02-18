using Microsoft.AspNetCore.Mvc;
using TechLibrary.Communication.Requests;

namespace TechLibrary.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(RequestUserJson request)
        {
            return Created();
        }


    }
}
