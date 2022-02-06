using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using puc.poc.modulo.financeiro.dominio.WriteModel;

namespace puc.poc.modulo.financeiro.repositorio.writemodel.Mappers
{
    public class AssociadoMap : IEntityTypeConfiguration<Associado>
    {
        public void Configure(EntityTypeBuilder<Associado> builder)
        {
            builder.ToTable("Associados");
            builder.HasKey(x => x.UniqueId);
            builder.HasMany(x => x.Boletos).WithOne(x => x.Associado);
        }
    }
}