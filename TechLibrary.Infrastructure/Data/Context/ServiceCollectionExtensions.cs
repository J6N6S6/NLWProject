using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TechLibrary.Infrastructure.Data.Context.SQLite;

namespace TechLibrary.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            // Configura o DbContext
            services.AddDbContext<TechLibraryDbContext>(options =>
            {
                options.UseSqlite(connectionString); // Substitua pelo provedor de banco de dados correto
            });

            // Outros serviços de infraestrutura podem ser registrados aqui

            return services;
        }
    }
}