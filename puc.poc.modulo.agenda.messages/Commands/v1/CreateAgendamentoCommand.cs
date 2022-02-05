using puc.poc.modulo.cross.Kafka.Interfaces;
using System;
using System.Runtime.Serialization;

namespace puc.poc.modulo.agenda.messages.Commands.v1
{
    [DataContract]
    public class CreateAgendamentoCommand : IMessage
    {
        public CreateAgendamentoCommand()
        {
            
        }

        public CreateAgendamentoCommand(string conveniado, string associado, string especialidade, DateTime dataAgendamento)
        {
            Conveniado = conveniado;
            Associado = associado;
            DataAgendamento = dataAgendamento;
            Especialidade = especialidade;
        }

        [DataMember(Order = 1)]
        public string Conveniado { get; }

        [DataMember(Order = 2)]
        public string Associado { get; }

        [DataMember(Order = 3)]
        public string Especialidade { get; }

        [DataMember(Order = 4)]
        public DateTime DataAgendamento { get; }
    }
}