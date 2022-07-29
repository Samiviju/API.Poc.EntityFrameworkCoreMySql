using Api.Poc.EntityFrameworkCoreMySql.Dominio.Entidades;
using Api.Poc.EntityFrameworkCoreMySql.Utilitario;
using Microsoft.EntityFrameworkCore;

namespace Api.Poc.EntityFrameworkCoreMySql.Infra.Contextos
{
    public partial class DbContextoRepositorios : DbContext
    {
        private readonly string BancoDeDados;

        public DbContextoRepositorios()
        {
            BancoDeDados = new CofreDeSenhasAws().ConnectionString;
        }

        public DbContextoRepositorios(DbContextOptions<DbContextoRepositorios> options) : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(BancoDeDados, new MySqlServerVersion(new Version(8, 0, 29)));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>();
        }
    }
}