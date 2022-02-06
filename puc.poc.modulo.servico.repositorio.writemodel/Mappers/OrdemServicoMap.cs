using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using puc.poc.modulo.servico.dominio.WriteModel;

namespace puc.poc.modulo.agenda.repositorio.writemodel.Mappers
{
    public class OrdemServicoMap : IEntityTypeConfiguration<OrdemServico>
    {
        public void Configure(EntityTypeBuilder<OrdemServico> builder)
        {
            builder.ToTable("OrdensServico");
            builder.HasKey(x => x.UniqueId);
            builder.HasOne(x => x.Servico).WithMany(x => x.Servicos);
            builder.HasOne(x => x.Associado).WithMany(x => x.Servicos);
        }
    }
}