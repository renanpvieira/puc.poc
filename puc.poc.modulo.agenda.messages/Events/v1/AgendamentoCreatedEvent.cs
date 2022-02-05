using puc.poc.modulo.cross.Kafka.Interfaces;
using System;
using System.Runtime.Serialization;

namespace puc.poc.modulo.agenda.messages.Events.v1
{
    [DataContract]
    public class AgendamentoCreatedEvent : IMessage
    {
        public AgendamentoCreatedEvent()
        {
            
        }

        public AgendamentoCreatedEvent(string uniqueId, DateTime dataAgendamentoInicio, DateTime dataAgendamentoFim)
        {
            UniqueId = uniqueId;
            DataAgendamentoInicio = dataAgendamentoInicio;
            DataAgendamentoFim = dataAgendamentoFim;
        }

        [DataMember(Order = 1)]
        public string UniqueId { get; }

        [DataMember(Order = 2)]
        public DateTime DataAgendamentoInicio { get; }

        [DataMember(Order = 3)]
        public DateTime DataAgendamentoFim { get; }
    }
}