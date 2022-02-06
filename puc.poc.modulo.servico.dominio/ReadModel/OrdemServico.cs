using MongoDB.Bson.Serialization.Attributes;

namespace puc.poc.modulo.servico.dominio.ReadModel
{
    public class OrdemServico : BaseEntity
    {
        [BsonElement("ValorTotal")]
        public double ValorTotal { get; set; }
    }
}
