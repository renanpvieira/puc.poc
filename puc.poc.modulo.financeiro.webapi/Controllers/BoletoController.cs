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
            System.Threading.Thread.Sleep(2000);

            var command = new CreateBoletoCommand("61fdb554623de0dbe71b568y", new DateTime(2022, 2, 10));
            await producer.ProduceAync(command);
            return this.Accepted();
        }
    }
}
