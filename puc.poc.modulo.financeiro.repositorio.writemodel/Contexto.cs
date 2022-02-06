using Microsoft.EntityFrameworkCore;
using puc.poc.modulo.agenda.repositorio.writemodel.Mappers;
using puc.poc.modulo.financeiro.dominio.WriteModel;
using puc.poc.modulo.financeiro.repositorio.writemodel.Mappers;

namespace puc.poc.modulo.financeiro.repositorio.writemodel
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BoletoMap());
            modelBuilder.ApplyConfiguration(new AssociadoMap());
        }

        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<Associado> Associados { get; set; }
    }
}