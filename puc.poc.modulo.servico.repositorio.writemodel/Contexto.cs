using Microsoft.EntityFrameworkCore;
using puc.poc.modulo.agenda.repositorio.writemodel.Mappers;
using puc.poc.modulo.servico.dominio.WriteModel;

namespace puc.poc.modulo.servico.repositorio.writemodel
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
            modelBuilder.ApplyConfiguration(new AssociadoMap());
            modelBuilder.ApplyConfiguration(new OrdemServicoMap());
            modelBuilder.ApplyConfiguration(new ServicoMap());
            modelBuilder.ApplyConfiguration(new ColaboradorMap());
        }

        public DbSet<OrdemServico> OrdensServico { get; set; }
        public DbSet<Associado> Associados { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
    }
}