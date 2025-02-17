using Microsoft.EntityFrameworkCore;
using ApiMatheus.Models;

namespace ApiMatheus.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Tabela de Presentes
        public DbSet<Presente> Presentes { get; set; }
        public DbSet<Convidado> Convidados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define a propriedade Id como chave primária
            modelBuilder.Entity<Presente>()
                .HasKey(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}