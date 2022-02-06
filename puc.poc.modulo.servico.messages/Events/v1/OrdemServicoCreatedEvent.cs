using puc.poc.modulo.cross.Kafka.Interfaces;
using System.Runtime.Serialization;

namespace puc.poc.modulo.servico.messages.Events.v1
{
    [DataContract]
    public class OrdemServicoCreatedEvent : IMessage
    {
        public OrdemServicoCreatedEvent()
        {
            
        }

        public OrdemServicoCreatedEvent(string uniqueId, double valorTotal)
        {
            UniqueId = uniqueId;
            ValorTotal = valorTotal;
        }

        [DataMember(Order = 1)]
        public string UniqueId { get; }

        [DataMember(Order = 2)]
        public double ValorTotal { get; }
    }
}