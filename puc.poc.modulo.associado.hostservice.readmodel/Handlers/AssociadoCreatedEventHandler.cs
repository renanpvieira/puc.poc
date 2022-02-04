using System;
using System.Threading.Tasks;
using KafkaFlow;
using KafkaFlow.TypedHandler;
using puc.poc.modulo.associado.messages.Events.v1;

namespace puc.poc.modulo.associado.hostservice.readmodel.Handlers
{
    public class AssociadoCreatedEventHandler : IMessageHandler<AssociadoCreatedEvent>
    {
        public Task Handle(IMessageContext context, AssociadoCreatedEvent message)
        {
            Console.WriteLine(
                "Partition: {0} | Offset: {1} | Nome: {2}",
                context.ConsumerContext.Partition,
                context.ConsumerContext.Offset,
                message.Nome);

            return Task.CompletedTask;
        }
    }
}