using System;
using System.Threading.Tasks;
using KafkaFlow;
using KafkaFlow.TypedHandler;
using puc.poc.modulo.servico.dominio.ReadModel;
using puc.poc.modulo.servico.messages.Events.v1;
using puc.poc.modulo.servico.repositorio.readmodel;

namespace puc.poc.modulo.servico.hostservice.readmodel.Handlers
{
    public class OrdemServicoCreatedEventHandler : IMessageHandler<OrdemServicoCreatedEvent>
    {
        private readonly IOrdemServicoRepositorio ordemServicoRepositorio;

        public OrdemServicoCreatedEventHandler(IOrdemServicoRepositorio ordemServicoRepositorio)
        {
            this.ordemServicoRepositorio = ordemServicoRepositorio;
        }

        public Task Handle(IMessageContext context, OrdemServicoCreatedEvent message)
        {
            Console.WriteLine("Partition: {0} | Offset: {1} | Message: OrdemServicoCreatedEvent",
                context.ConsumerContext.Partition,
                context.ConsumerContext.Offset);

            var ordemServico = new OrdemServico
            {
                Id = message.UniqueId,
                ValorTotal = message.ValorTotal
            };

            ordemServicoRepositorio.InsertAsync(ordemServico);

            return Task.CompletedTask;
        }
    }
}
