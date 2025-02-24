using System.Net;

namespace TechLibrary.Exception
{
    public class ErrorOnValidationException : TechLibraryException
    {
        private readonly List<string> _errorMessages;
        public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
        {
            _errorMessages = errorMessages; //Atribuo a lista de mensagens de erro no construtor
        }

        public override List<string> GetErrorMessages() => _errorMessages; //Retorno a lista de mensagens de erro

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest; //Retorno um status code 400 se houver erro de validação
    }
}