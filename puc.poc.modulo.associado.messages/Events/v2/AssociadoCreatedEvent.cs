using System;
using System.Runtime.Serialization;
using puc.poc.modulo.cross.Kafka.Interfaces;

namespace puc.poc.modulo.associado.messages.Events.v2
{
    [DataContract]
    public class AssociadoCreatedEvent : IMessage
    {
        public AssociadoCreatedEvent()
        {

        }

        public AssociadoCreatedEvent(Guid uniqueId, string nome, int idade)
        {
            UniqueId = uniqueId;
            Nome = nome;
            Idade = idade;
        }

        [DataMember(Order = 1)]
        public Guid UniqueId { get; }

        [DataMember(Order = 2)]
        public string Nome { get; }
        
        [DataMember(Order = 3)]
        public int Idade { get; }
    }
}