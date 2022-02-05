using puc.poc.modulo.agenda.dominio.WriteModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace puc.poc.modulo.agenda.repositorio.writemodel.Mappers
{
    public class AgendamentoMap : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("Agendamentos");
            builder.HasKey(x => x.UniqueId);
            builder.HasOne(x => x.Associado).WithMany(x => x.Agendamentos);
            builder.HasOne(x => x.Conveniado).WithMany(x => x.Agendamentos);
            builder.HasOne(x => x.Especialidade).WithMany(x => x.Agendamentos);
        }
    }
}
