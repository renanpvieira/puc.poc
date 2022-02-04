using System;
using System.Runtime.Serialization;
using puc.poc.modulo.cross.Kafka.Interfaces;

namespace puc.poc.modulo.associado.messages.Commands.v1
{
    [DataContract]
    public class CreateAssociadoCommand : IMessage
    {
        public CreateAssociadoCommand()
        {
            
        }  

        public CreateAssociadoCommand(string nome, int cpf, DateTime dataNascimento)
        {
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
        }

        [DataMember(Order = 1)]
        public string Nome { get; }

        [DataMember(Order = 2)]
        public int CPF { get; }

        [DataMember(Order = 3)]
        public DateTime DataNascimento { get; }
    }
}