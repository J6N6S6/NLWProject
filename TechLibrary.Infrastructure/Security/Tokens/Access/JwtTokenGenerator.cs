using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TechLibrary.Infrastructure.Data.Domain.Entities;

namespace TechLibrary.Infrastructure.Security.Tokens.Access
{
    public class JwtTokenGenerator
    {
        public string Generate(User user)
        {
            var claims = new List<Claim> //Precisamos de uma lista de claims para o token, o claim é uma informação sobre o usuário
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), //Id do usuário, não quero expor os outros dados do usuário,
                                                                          //colocar valor que não seja sensível ou alterável
            };

            var tokenDescriptor = new SecurityTokenDescriptor //Precisamos descrever o token
            {
                Expires = DateTime.UtcNow.AddMinutes(30),
                Subject = new ClaimsIdentity(claims), //Identidade do token
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler(); //Manipulador de token JWT

            var securityToken = tokenHandler.CreateToken(tokenDescriptor); //Criar token com base na descrição

            return tokenHandler.WriteToken(securityToken); //Retornar token gerado em string
        }

        private static SymmetricSecurityKey SecurityKey()
        {
            string secretKey = "Maple é a melhor cachorra do mundo!";


            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        }
    }
}
