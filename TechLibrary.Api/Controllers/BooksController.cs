using Microsoft.AspNetCore.Mvc;
using TechLibrary.Application.Interfaces.Books;
using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;

namespace TechLibrary.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IFilterBooksUseCase _filterBooksUseCase;

        public BooksController(IFilterBooksUseCase filterBooksUseCase)
        {
            _filterBooksUseCase = filterBooksUseCase;
        }

        [HttpGet("Filter")]
        [ProducesResponseType(typeof(ResponseBooksJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Filter(int pageNumber, string? title)
        {
            var result = _filterBooksUseCase.Execute(new RequestFilterBooksJson
            {
                PageNumber = pageNumber,
                Title = title
            });

            if (result.Books.Count > 0)
            {
                return Ok(result);
            }

            return NoContent();
        }
    }
}
