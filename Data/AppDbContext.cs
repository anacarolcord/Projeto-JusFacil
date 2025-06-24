using Microsoft.EntityFrameworkCore;
using JusFacil.API.Models;


namespace JusFacil.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Processo> Processos { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Financeiro> Financeiros { get; set; }
        public DbSet<Documento> Documentos { get; set; }
    }
}





