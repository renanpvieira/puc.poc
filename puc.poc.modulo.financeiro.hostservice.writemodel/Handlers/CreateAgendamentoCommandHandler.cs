using System;
using System.Linq;
using System.Threading.Tasks;
using KafkaFlow;
using KafkaFlow.TypedHandler;
using MongoDB.Bson;
using puc.poc.modulo.cross.Kafka.Interfaces;
using puc.poc.modulo.financeiro.dominio.WriteModel;
using puc.poc.modulo.financeiro.messages.Commands.v1;
using puc.poc.modulo.financeiro.messages.Events.v1;
using puc.poc.modulo.financeiro.repositorio.writemodel;

namespace puc.poc.modulo.financeiro.hostservice.writemodel.Handlers
{
    public class CreateAgendamentoCommandHandler : IMessageHandler<CreateBoletoCommand>
    {
        private readonly Contexto contexto;
        private readonly IMessagesProducer producer;

        public CreateAgendamentoCommandHandler(Contexto contexto, IMessagesProducer producer)
        {
            this.contexto = contexto;
            this.producer = producer;
        }

        public Task Handle(IMessageContext context, CreateBoletoCommand message)
        {
            Console.WriteLine("Partition: {0} | Offset: {1} | Message: CreateBoletoCommand",
                context.ConsumerContext.Partition,
                context.ConsumerContext.Offset);

            var associado = contexto.Associados.FirstOrDefault(x => x.UniqueId == message.Associado);

            var boleto = new Boleto
            {
                UniqueId = ObjectId.GenerateNewId().ToString(),
                Associado = associado,
                DataVencimento = message.DataVencimento,
                Valor = 10,
                Numero = 1,
                Banco = "Bradesco",
                CodigoBarras = 10298,
                DataEmissao = DateTime.Now
            };

            contexto.Boletos.Add(boleto);
            contexto.SaveChangesAsync();

            var @event = new BoletoCreatedEvent(boleto.Associado.UniqueId, boleto.DataVencimento, boleto.Valor);
            producer.ProduceAync(@event);

            return Task.CompletedTask;
        }
    }
}