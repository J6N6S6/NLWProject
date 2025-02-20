using System.Net;

namespace TechLibrary.Exception
{
    public abstract class TechLibraryException : SystemException //Não lanço esta exceção diretamente
    {
        public abstract List<string> GetErrorMessages();
        public abstract HttpStatusCode GetStatusCode();
    }
}
