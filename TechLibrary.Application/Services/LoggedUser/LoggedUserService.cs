using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TechLibrary.Application.Interfaces.LoggedUser;
using TechLibrary.Infrastructure.Data.Context.SQLite;
using TechLibrary.Infrastructure.Data.Domain.Entities;

namespace TechLibrary.Application.Services
{
    public class LoggedUserService : ILoggedUser
    {
        private readonly IHttpContextAccessor _httpContextAcessor;
        private readonly TechLibraryDbContext _dbContext;
        public LoggedUserService(IHttpContextAccessor httpContextAccessor, TechLibraryDbContext dbContext)
        {
            _httpContextAcessor = httpContextAccessor;
            _dbContext = dbContext;
        }

        public User GetUser()
        {
            //Bearer token

            var authentication = _httpContextAcessor.HttpContext?.Request.Headers["Authorization"].ToString();

            authentication = authentication["Bearer ".Length..].Trim(); //Trim na quantidade de caracteres

            var userId = DecodeTokenAndGetUserId(authentication);

            return _dbContext.Users.FirstOrDefault(u => u.Id == userId);
        }


        private Guid DecodeTokenAndGetUserId(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // Lê o token JWT
            var jwtToken = tokenHandler.ReadJwtToken(token);

            // Obtém a claim do ID do usuário
            var userIdClaim = jwtToken.Claims.First(c => c.Type == JwtRegisteredClaimNames.NameId).Value;

            if (userIdClaim == null)
            {
                throw new InvalidOperationException("Invalid token.");
            }

            return Guid.Parse(userIdClaim);
        }
    }
}
