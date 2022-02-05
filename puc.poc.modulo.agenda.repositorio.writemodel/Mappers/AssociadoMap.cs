using puc.poc.modulo.agenda.dominio.WriteModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace puc.poc.modulo.agenda.repositorio.writemodel.Mappers
{
    public class AssociadoMap : IEntityTypeConfiguration<Associado>
    {
        public void Configure(EntityTypeBuilder<Associado> builder)
        {
            builder.ToTable("Associados");
            builder.HasKey(x => x.UniqueId);
            builder.HasMany(x => x.Agendamentos).WithOne(x => x.Associado);
        }
    }
}