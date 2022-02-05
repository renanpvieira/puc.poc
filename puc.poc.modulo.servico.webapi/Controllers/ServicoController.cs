using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using puc.poc.modulo.servico.dominio.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using puc.poc.modulo.servico.repositorio.readmodel;

namespace puc.poc.modulo.servico.webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicoController : ControllerBase
    {

        private readonly ILogger<ServicoController> logger;
        private readonly IServicoRepositorio repositorio;

        public ServicoController(ILogger<ServicoController> logger, IServicoRepositorio repositorio)
        {
            this.logger = logger;
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<Servico>> Get(string tipo)
        {
            var servicos = await repositorio.GetByTipoAsync(tipo);
            return this.Ok(servicos);
        }
    }
}
