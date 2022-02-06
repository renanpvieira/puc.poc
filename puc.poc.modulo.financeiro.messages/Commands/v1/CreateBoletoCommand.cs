using puc.poc.modulo.cross.Kafka.Interfaces;
using System;
using System.Runtime.Serialization;

namespace puc.poc.modulo.financeiro.messages.Commands.v1
{
    [DataContract]
    public class CreateBoletoCommand : IMessage
    {
        public CreateBoletoCommand()
        {
            
        }

        public CreateBoletoCommand(string associado, DateTime dataVencimento)
        {
            Associado = associado;
            DataVencimento = dataVencimento;
        }

        [DataMember(Order = 1)]
        public string Associado { get; }

        [DataMember(Order = 2)]
        public DateTime DataVencimento { get; }
    }
}