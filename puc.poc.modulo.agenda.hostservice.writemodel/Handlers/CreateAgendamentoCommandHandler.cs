using System;
using System.Linq;
using System.Threading.Tasks;
using KafkaFlow;
using KafkaFlow.TypedHandler;
using MongoDB.Bson;
using puc.poc.modulo.agenda.dominio.WriteModel;
using puc.poc.modulo.agenda.messages.Commands.v1;
using puc.poc.modulo.agenda.messages.Events.v1;
using puc.poc.modulo.agenda.repositorio.writemodel;
using puc.poc.modulo.cross.Kafka.Interfaces;

namespace puc.poc.modulo.agenda.hostservice.writemodel.Handlers
{
    public class CreateAgendamentoCommandHandler : IMessageHandler<CreateAgendamentoCommand>
    {
        private readonly Contexto contexto;
        private readonly IMessagesProducer producer;

        public CreateAgendamentoCommandHandler(Contexto contexto, IMessagesProducer producer)
        {
            this.contexto = contexto;
            this.producer = producer;
        }

        public Task Handle(IMessageContext context, CreateAgendamentoCommand message)
        {
            Console.WriteLine("Partition: {0} | Offset: {1} | Message: CreateAgendamentoCommand",
                context.ConsumerContext.Partition,
                context.ConsumerContext.Offset);

            var associado = contexto.Associados.FirstOrDefault(x => x.UniqueId == message.Associado);
            var conveniado = contexto.Conveniados.FirstOrDefault(x => x.UniqueId == message.Conveniado); 
            var especialidade = contexto.EspecialidadeS.FirstOrDefault(x => x.UniqueId == message.Especialidade);

            var agendamento = new Agendamento
            {
                UniqueId = ObjectId.GenerateNewId().ToString(),
                Associado = associado,
                Conveniado = conveniado,
                Especialidade = especialidade,
                DataHoraInicio = message.DataAgendamento,
                DataHoraFim = message.DataAgendamento
            };
            
            agendamento.CalculaDataHoraFim();

            contexto.Agendamentos.Add(agendamento);
            contexto.SaveChangesAsync();

            var @event = new AgendamentoCreatedEvent(agendamento.UniqueId, agendamento.DataHoraInicio, agendamento.DataHoraFim);
            producer.ProduceAync(@event);

            return Task.CompletedTask;
        }
    }
}