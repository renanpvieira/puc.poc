using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult> Get(string uniqueId)
        {
            var associado = GetAssociados().FirstOrDefault(x => x.UniqueId == uniqueId);
            return this.Ok(associado);
        }

        [HttpGet("buscar")]
        public async Task<ActionResult> Get()
        {
            return this.Ok(GetAssociados());
        }

        [HttpPost]
        public async Task<ActionResult> Post(string nome, int cpf, DateTime dataNascimento)
        {
            var command = new CreateAssociadoCommand(nome, cpf, dataNascimento);
            await producer.ProduceAync(command);
            return this.Accepted();
        }

        private List<Associado> GetAssociados()
        {
            return new List<Associado>()
            {
                new Associado { UniqueId = "61fdb554623de0dbe71b568y", Nome = "Peter Parker", CPF = "11997326478" },
                new Associado { UniqueId = "61fdb554623de0dbe71b570y", Nome = "Tony Stark", CPF = "21897526577" },
                new Associado { UniqueId = "61fdb554623de0dbe71b569y", Nome = "Steven Rogers", CPF = "31797626672" },
                new Associado { UniqueId = "61fdb554623de0dbe71b520y", Nome = "Brian Banner", CPF = "41697726971" }
            };
        }
    }
}