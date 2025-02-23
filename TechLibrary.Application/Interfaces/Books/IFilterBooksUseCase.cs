using TechLibrary.Communication.Requests;
using TechLibrary.Communication.Responses;

namespace TechLibrary.Application.Interfaces.Books
{
    public interface IFilterBooksUseCase
    {
        public ResponseBooksJson Execute(RequestFilterBooksJson request);
    }
}
