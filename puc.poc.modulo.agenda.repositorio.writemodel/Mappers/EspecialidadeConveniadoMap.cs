using puc.poc.modulo.agenda.dominio.WriteModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace puc.poc.modulo.agenda.repositorio.writemodel.Mappers
{
    public class EspecialidadeConveniadoMap : IEntityTypeConfiguration<EspecialidadeConveniado>
    {
        public void Configure(EntityTypeBuilder<EspecialidadeConveniado> builder)
        {
            builder.ToTable("EspecialidadesConveniado");
            builder.HasKey(x => x.UniqueId);
            builder.HasMany(x => x.Agendamentos).WithOne(x => x.Especialidade);
        }
    }
}