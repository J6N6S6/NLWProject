using Microsoft.EntityFrameworkCore;
using TechLibrary.Infrastructure.Data.Domain.Entities;

namespace TechLibrary.Infrastructure.Data.Context.SQLite
{
    public class TechLibraryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } //A propriedade deve ter o nome da tabela no banco de dados
        public DbSet<Book> Books { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }

        public TechLibraryDbContext(DbContextOptions<TechLibraryDbContext> options) : base(options) { }
        public TechLibraryDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\jonas\\OneDrive\\Área de Trabalho\\Jonas\\Estudos Jonas\\Banco de dados\\TechLibrary\\TechLibraryDb.db");
        }
    }
}
