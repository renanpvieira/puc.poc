using System;
using MongoDB.Bson.Serialization.Attributes;

namespace puc.poc.modulo.agenda.dominio.ReadModel
{
    public class Agendamento : BaseEntity
    {
        [BsonElement("DataAgendamentoInicio")]
        public DateTime DataAgendamentoInicio { get; set; }

        [BsonElement("DataAgendamentoFim")]
        public DateTime DataAgendamentoFim { get; set; }
    }
}