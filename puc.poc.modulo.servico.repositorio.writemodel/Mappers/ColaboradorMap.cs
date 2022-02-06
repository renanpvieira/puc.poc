using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using puc.poc.modulo.servico.dominio.WriteModel;

namespace puc.poc.modulo.agenda.repositorio.writemodel.Mappers
{
    public class ColaboradorMap : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.ToTable("Colaboradores");
            builder.HasKey(x => x.UniqueId);
            builder.HasMany(x => x.Servicos).WithOne(x => x.Colaborador);
        }
    }
}