using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using puc.poc.modulo.financeiro.dominio.WriteModel;

namespace puc.poc.modulo.agenda.repositorio.writemodel.Mappers
{
    public class BoletoMap : IEntityTypeConfiguration<Boleto>
    {
        public void Configure(EntityTypeBuilder<Boleto> builder)
        {
            builder.ToTable("Boletos");
            builder.HasKey(x => x.UniqueId);
            builder.HasOne(x => x.Associado).WithMany(x => x.Boletos);
        }
    }
}
