using System;
using System.Threading.Tasks;
using KafkaFlow;
using KafkaFlow.TypedHandler;
using puc.poc.modulo.agenda.dominio.ReadModel;
using puc.poc.modulo.agenda.messages.Events.v1;
using puc.poc.modulo.agenda.repositorio.readmodel;

namespace puc.poc.modulo.agenda.hostservice.readmodel.Handlers
{
    public class AgendamentoCreatedEventHandler : IMessageHandler<AgendamentoCreatedEvent>
    {
        private readonly IAgendaRepositorio agendaRepositorio;

        public AgendamentoCreatedEventHandler(IAgendaRepositorio agendaRepositorio)
        {
            this.agendaRepositorio = agendaRepositorio;
        }

        public Task Handle(IMessageContext context, AgendamentoCreatedEvent message)
        {
            Console.WriteLine("Partition: {0} | Offset: {1} | Message: AgendamentoCreatedEvent",
                context.ConsumerContext.Partition,
                context.ConsumerContext.Offset);

            var agendamento = new Agendamento
            {
                Id = message.UniqueId,
                DataAgendamentoFim = message.DataAgendamentoFim,
                DataAgendamentoInicio = message.DataAgendamentoInicio
            };

            agendaRepositorio.InsertAsync(agendamento);

            return Task.CompletedTask;
        }
    }
}
