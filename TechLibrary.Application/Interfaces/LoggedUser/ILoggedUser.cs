using TechLibrary.Infrastructure.Data.Domain.Entities;

namespace TechLibrary.Application.Interfaces.LoggedUser
{
    public interface ILoggedUser
    {
        User GetUser();
    }
}