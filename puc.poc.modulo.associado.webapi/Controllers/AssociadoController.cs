using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using puc.poc.modulo.associado.dominio.ReadModel;
using puc.poc.modulo.associado.messages.Commands.v1;
using puc.poc.modulo.cross.Kafka.Interfaces;

namespace puc.poc.modulo.associado.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssociadoController : ControllerBase
    {
        private readonly ILogger<AssociadoController> logger;
        private readonly IMessagesProducer producer;

        public AssociadoController(ILogger<AssociadoController> logger, IMessagesProducer producer)
        {
            this.logger = logger;
            this.producer = producer;
        }

        [HttpGet]
        public async Task<ActionResult> Get(Guid uniqueId)
        {
            var associado = new Associado
            {
                UniqueId = uniqueId,
                Nome = "Linus Benedict Torvalds" 

            };

            return this.Ok(associado);
        }

        [HttpPost]
        public async Task<ActionResult> Post(string nome, int cpf, DateTime dataNascimento)
        {
            var command = new CreateAssociadoCommand(nome, cpf, dataNascimento);
            await producer.ProduceAync(command);
            return this.Accepted();
        }
    }
}