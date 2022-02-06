using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using puc.poc.modulo.servico.dominio.ReadModel;
using System.Threading.Tasks;
using puc.poc.modulo.cross.Kafka.Interfaces;
using puc.poc.modulo.servico.repositorio.readmodel;
using puc.poc.modulo.servico.messages.Commands.v1;

namespace puc.poc.modulo.servico.webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicoController : ControllerBase
    {

        private readonly ILogger<ServicoController> logger;
        private readonly IServicoRepositorio repositorio;
        private readonly IMessagesProducer producer;

        public ServicoController(ILogger<ServicoController> logger, IServicoRepositorio repositorio, IMessagesProducer producer)
        {
            this.logger = logger;
            this.repositorio = repositorio;
            this.producer = producer;
        }

        [HttpGet]
        public async Task<ActionResult<Servico>> Get(string tipo)
        {
            var servicos = await repositorio.GetByTipoAsync(tipo);
            return this.Ok(servicos);
        }

        [HttpGet("buscar")]
        public async Task<ActionResult<Servico>> Get()
        {
            var servicos = await repositorio.GetAsync();
            return this.Ok(servicos);
        }

        [HttpPost]
        public async Task<ActionResult<Servico>> Post(string colaborador, string associado, string especialidade, string texto)
        {
            var command = new CreateOrdemServicoCommand(colaborador, associado, especialidade, texto);
            await producer.ProduceAync(command);
            return this.Accepted();
        }
    }
}
