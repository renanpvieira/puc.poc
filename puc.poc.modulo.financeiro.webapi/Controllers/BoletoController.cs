using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using puc.poc.modulo.cross.Kafka.Interfaces;
using puc.poc.modulo.financeiro.messages.Commands.v1;
using System;
using System.Threading.Tasks;

namespace puc.poc.modulo.financeiro.webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoletoController : ControllerBase
    {
        private readonly IMessagesProducer producer;
        private readonly ILogger<BoletoController> _logger;

        public BoletoController(ILogger<BoletoController> logger, IMessagesProducer producer)
        {
            _logger = logger;
            this.producer = producer;
        }

        [HttpPost]
        public async Task<IActionResult> Post(string associado, DateTime dataVencimento)
        {
            var command = new CreateBoletoCommand(associado, dataVencimento);
            await producer.ProduceAync(command);
            return this.Accepted();
        }
    }
}
