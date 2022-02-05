using Microsoft.EntityFrameworkCore;
using puc.poc.modulo.agenda.dominio.WriteModel;
using puc.poc.modulo.agenda.repositorio.writemodel.Mappers;

namespace puc.poc.modulo.agenda.repositorio.writemodel
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
            modelBuilder.ApplyConfiguration(new AgendamentoMap());
            modelBuilder.ApplyConfiguration(new AssociadoMap());
            modelBuilder.ApplyConfiguration(new ConveniadoMap());
            modelBuilder.ApplyConfiguration(new EspecialidadeConveniadoMap());
        }

        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Associado> Associados { get; set; }
        public DbSet<Conveniado> Conveniados { get; set; }
        public DbSet<EspecialidadeConveniado> EspecialidadeS { get; set; }
    }
}