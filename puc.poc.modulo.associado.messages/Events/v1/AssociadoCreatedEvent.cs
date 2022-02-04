using System;
using System.Runtime.Serialization;
using puc.poc.modulo.cross.Kafka.Interfaces;

namespace puc.poc.modulo.associado.messages.Events.v1
{
    [DataContract]
    public class AssociadoCreatedEvent : IMessage
    {
        public AssociadoCreatedEvent()
        {
            
        }

        public AssociadoCreatedEvent(Guid uniqueId, string nome)
        {
            UniqueId = uniqueId;
            Nome = nome;
        }

        [DataMember(Order = 1)]
        public Guid UniqueId { get; }

        [DataMember(Order = 2)]
        public string Nome { get; }
    }
}