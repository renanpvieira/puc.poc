using puc.poc.modulo.cross.Kafka.Interfaces;
using System.Runtime.Serialization;

namespace puc.poc.modulo.servico.messages.Commands.v1
{
    [DataContract]
    public class CreateOrdemServicoCommand : IMessage
    {
        public CreateOrdemServicoCommand()
        {
            
        }

        public CreateOrdemServicoCommand(string colaborador, string associado, string especialidade, string texto)
        {
            Colaborador = colaborador;
            Associado = associado;
            Especialidade = especialidade;
            Texto = texto;
        }

        [DataMember(Order = 1)]
        public string Colaborador { get; }

        [DataMember(Order = 2)]
        public string Associado { get; }

        [DataMember(Order = 3)]
        public string Especialidade { get; }

        [DataMember(Order = 4)]
        public string Texto { get; }
    }
}