using puc.poc.modulo.agenda.dominio.WriteModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace puc.poc.modulo.agenda.repositorio.writemodel.Mappers
{
    public class ConveniadoMap : IEntityTypeConfiguration<Conveniado>
    {
        public void Configure(EntityTypeBuilder<Conveniado> builder)
        {
            builder.ToTable("Conveniados");
            builder.HasKey(x => x.UniqueId);
            builder.HasMany(x => x.Agendamentos).WithOne(x => x.Conveniado);
        }
    }
}