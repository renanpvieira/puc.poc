using System;
using System.Threading.Tasks;
using KafkaFlow;
using KafkaFlow.TypedHandler;
using puc.poc.modulo.financeiro.dominio.ReadModel;
using puc.poc.modulo.financeiro.messages.Events.v1;
using puc.poc.modulo.financeiro.repositorio.readmodel;

namespace puc.poc.modulo.financeiro.hostservice.readmodel.Handlers
{
    public class BoletoCreatedEventHandler : IMessageHandler<BoletoCreatedEvent>
    {
        private readonly IBoletoRepositorio boletoRepositorio;

        public BoletoCreatedEventHandler(IBoletoRepositorio boletoRepositorio)
        {
            this.boletoRepositorio = boletoRepositorio;
        }

        public Task Handle(IMessageContext context, BoletoCreatedEvent message)
        {
            Console.WriteLine("Partition: {0} | Offset: {1} | Message: BoletoCreatedEvent",
                context.ConsumerContext.Partition,
                context.ConsumerContext.Offset);

            var boleto = new Boleto
            {
                Associado = message.Associado,
                Valor = message.Valor,
                DataVencimento = message.DataVencimento
            };

            boletoRepositorio.InsertAsync(boleto);

            return Task.CompletedTask;
        }
    }
}