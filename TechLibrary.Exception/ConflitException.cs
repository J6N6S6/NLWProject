using System.Net;

namespace TechLibrary.Exception
{
    public class ConflitException : TechLibraryException
    {
        public ConflitException(string message) : base(message) { }

        public override List<string> GetErrorMessages() => [Message];

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.Conflict;
    }
}