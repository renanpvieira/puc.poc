using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using puc.poc.modulo.servico.dominio.WriteModel;

namespace puc.poc.modulo.agenda.repositorio.writemodel.Mappers
{
    public class ServicoMap : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.ToTable("Servicos");
            builder.HasKey(x => x.UniqueId);
            builder.HasMany(x => x.Servicos).WithOne(x => x.Servico);
        }
    }
}