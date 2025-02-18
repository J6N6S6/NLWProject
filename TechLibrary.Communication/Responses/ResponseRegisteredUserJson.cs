using System.Security.Cryptography;

namespace TechLibrary.Communication.Responses
{
    internal class ResponseRegisteredUserJson
    {
        public string Name { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
    }
}
