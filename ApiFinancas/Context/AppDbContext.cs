using Microsoft.EntityFrameworkCore;

namespace ApiFinancas.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Conta> Contas { get; set; }
        public DbSet<CategoriaConta> CategoriasConta { get; set; }
    }
}
