using System;
using System.Threading.Tasks;
using KafkaFlow;
using KafkaFlow.TypedHandler;
using puc.poc.modulo.associado.messages.Commands.v1;
using V1 = puc.poc.modulo.associado.messages.Events.v1;
using V2 = puc.poc.modulo.associado.messages.Events.v2;
using puc.poc.modulo.cross.Kafka.Interfaces;
using puc.poc.modulo.associado.dominio.WriteModel;

namespace puc.poc.modulo.associado.hostservice.writemodel.Handlers
{
    public class CreateAssociadoCommandHandler : IMessageHandler<CreateAssociadoCommand>
    {
        private readonly IMessagesProducer producer;

        public CreateAssociadoCommandHandler(IMessagesProducer producer)
        {
            this.producer = producer;
        }

        public Task Handle(IMessageContext context, CreateAssociadoCommand message)
        {
            var associado = new Associado
            {
                UniqueId = Guid.NewGuid(),
                Nome =  message.Nome,
                CPF = message.CPF,
                DataNascimento = message.DataNascimento
            };

            var associadoCreatedEventV1 = 
                new V1.AssociadoCreatedEvent(associado.UniqueId, message.Nome);
            
            var associadoCreatedEventV2 = 
                new V2.AssociadoCreatedEvent(associado.UniqueId, message.Nome, associado.CalculaIdade());

            this.producer.ProduceAync(associadoCreatedEventV1);
            this.producer.ProduceAync(associadoCreatedEventV2);

            return Task.CompletedTask;
        }
    }
}

/*
 *
 *            Console.WriteLine(
                "Partition: {0} | Offset: {1} | Nome: {2} | CPF: {3}",
                context.ConsumerContext.Partition,
                context.ConsumerContext.Offset,
                message.Nome,
                message.CPF);
 *
 */