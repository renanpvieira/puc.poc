using System;
using System.Linq;
using System.Threading.Tasks;
using KafkaFlow;
using KafkaFlow.TypedHandler;
using MongoDB.Bson;
using puc.poc.modulo.cross.Kafka.Interfaces;
using puc.poc.modulo.servico.dominio.service;
using puc.poc.modulo.servico.messages.Commands.v1;
using puc.poc.modulo.servico.repositorio.writemodel;
using puc.poc.modulo.servico.dominio.WriteModel;
using puc.poc.modulo.servico.messages.Events.v1;

namespace puc.poc.modulo.servico.hostservice.writemodel.Handlers
{
    public class CreateOrdemServicoCommandHandler : IMessageHandler<CreateOrdemServicoCommand>
    {
        private readonly Contexto contexto;
        private readonly IMessagesProducer producer;

        public CreateOrdemServicoCommandHandler(Contexto contexto, IMessagesProducer producer)
        {
            this.contexto = contexto;
            this.producer = producer;
        }

        public Task Handle(IMessageContext context, CreateOrdemServicoCommand message)
        {
            Console.WriteLine("Partition: {0} | Offset: {1} | Message: CreateOrdemServicoCommand",
                context.ConsumerContext.Partition,
                context.ConsumerContext.Offset);

            var associado = contexto.Associados.FirstOrDefault(x => x.UniqueId == message.Associado);
            var colaborador = contexto.Colaboradores.FirstOrDefault(x => x.UniqueId == message.Colaborador); 
            var especialidade = contexto.Servicos.FirstOrDefault(x => x.UniqueId == message.Especialidade);
            
            var ordemServico = new OrdemServico
            {
                UniqueId = ObjectId.GenerateNewId().ToString(),
                Associado = associado,
                Colaborador = colaborador,
                Servico = especialidade,
                DataServico = DateTime.Now,
                Texto = message.Texto
            };
            
            contexto.OrdensServico.Add(ordemServico);
            contexto.SaveChangesAsync();

            var calculaValorOrdemService = new CalculaValorOrdem();
            var valorOrdemServico = calculaValorOrdemService.CalculaValor(ordemServico);

            var @event = new OrdemServicoCreatedEvent(ordemServico.UniqueId, valorOrdemServico);
            producer.ProduceAync(@event);

            return Task.CompletedTask;
        }
    }
}