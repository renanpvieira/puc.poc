using MongoDB.Bson.Serialization.Attributes;

namespace puc.poc.modulo.servico.dominio.ReadModel
{
    public class Servico : BaseEntity
    {
        [BsonElement("Descricao")]
        public string Descricao { get; set; } = null!;

        [BsonElement("Tipo")]
        public string Tipo { get; set; } = null!;
    }
}