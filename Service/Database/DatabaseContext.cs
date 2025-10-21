using CadastroCliente.Model.Fornecedor;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Service.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }


        public DbSet<Fornecedor> Fornecedores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Fornecedor>().Property(f=> f.Cnpj).HasMaxLength(14).IsFixedLength().IsRequired(); 
            modelBuilder.Entity<Fornecedor>().Property(f => f.Endereco).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Fornecedor>().Property(f => f.Nome).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Fornecedor>().Property(f => f.Cep).HasMaxLength(8).IsFixedLength().IsRequired();

            modelBuilder.Entity<Fornecedor>().HasAlternateKey(f => f.Cnpj);






            base.OnModelCreating(modelBuilder);
        }
    }
}
