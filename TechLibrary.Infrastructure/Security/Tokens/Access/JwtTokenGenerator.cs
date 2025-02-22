using Microsoft.IdentityModel.Tokens;
using TechLibrary.Infrastructure.Data.Domain.Entities;

namespace TechLibrary.Infrastructure.Security.Tokens.Access
{
    public class JwtTokenGenerator
    {
        public string Generate(User user)
        {
            var tokenDescriptor = new SecurityTokenDescriptor //Precisamos descrever o token
            {
                Expires = DateTime.UtcNow.AddMinutes(30),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey")), SecurityAlgorithms.HmacSha256Signature)
            };
        }
    }
}
