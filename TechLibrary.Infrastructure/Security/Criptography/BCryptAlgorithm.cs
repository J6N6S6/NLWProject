using TechLibrary.Infrastructure.Data.Domain.Entities;

namespace TechLibrary.Infrastructure.Security.Criptography
{
    public class BCryptAlgorithm
    {
        public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        public bool Verify(string password, User user) => BCrypt.Net.BCrypt.Verify(password, user.Password); //Evitar passar dois parâmetros do mesmo tipo
    }
}
