using System;
using MongoDB.Bson.Serialization.Attributes;

namespace puc.poc.modulo.financeiro.dominio.ReadModel
{
    public class Boleto : BaseEntity
    {
        [BsonElement("DataVencimento")]
        public DateTime DataVencimento { get; set; }

        [BsonElement("Associado")]
        public string Associado { get; set; }

        [BsonElement("Valor")]
        public double Valor { get; set; }
    }
}
