using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using puc.poc.modulo.agenda.messages.Commands.v1;
using System;
using System.Threading.Tasks;
using puc.poc.modulo.cross.Kafka.Interfaces;

namespace puc.poc.modulo.agenda.webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgendaController : ControllerBase
    {
        private readonly ILogger<AgendaController> _logger;
        private readonly IMessagesProducer producer;

        public AgendaController(ILogger<AgendaController> logger, IMessagesProducer producer)
        {
            _logger = logger;
            this.producer = producer;
        }

        [HttpPost]
        public async Task<IActionResult> Post(string conveniado, string associado, string especialidade, DateTime dataAgendamento)
        {
            var command = new CreateAgendamentoCommand(conveniado, associado, especialidade, dataAgendamento);
            await producer.ProduceAync(command);
            return this.Accepted();
        }
    }
}