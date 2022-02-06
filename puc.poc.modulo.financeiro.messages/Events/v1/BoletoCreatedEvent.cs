using puc.poc.modulo.cross.Kafka.Interfaces;
using System;
using System.Runtime.Serialization;

namespace puc.poc.modulo.financeiro.messages.Events.v1
{
    [DataContract]
    public class BoletoCreatedEvent : IMessage
    {
        public BoletoCreatedEvent()
        {
            
        }

        public BoletoCreatedEvent(string associado, DateTime dataVencimento, double valor)
        {
            Associado = associado;
            DataVencimento = dataVencimento;
            Valor = valor;
        }

        [DataMember(Order = 1)]
        public string Associado { get; }

        [DataMember(Order = 2)]
        public DateTime DataVencimento { get; }

        [DataMember(Order = 3)]
        public double Valor { get; }
    }
}