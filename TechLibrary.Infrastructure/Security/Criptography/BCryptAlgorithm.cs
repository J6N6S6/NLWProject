namespace TechLibrary.Infrastructure.Security.Criptography
{
    public class BCryptAlgorithm
    {
        public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
    }
}
