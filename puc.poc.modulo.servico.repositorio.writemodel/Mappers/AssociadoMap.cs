using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using puc.poc.modulo.servico.dominio.WriteModel;

namespace puc.poc.modulo.agenda.repositorio.writemodel.Mappers
{
    public class AssociadoMap : IEntityTypeConfiguration<Associado>
    {
        public void Configure(EntityTypeBuilder<Associado> builder)
        {
            builder.ToTable("Associados");
            builder.HasKey(x => x.UniqueId);
            builder.HasMany(x => x.Servicos).WithOne(x => x.Associado);
        }
    }
}