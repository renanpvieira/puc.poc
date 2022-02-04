using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace puc.poc.modulo.basedata.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : ControllerBase
    {

        private readonly ILogger<CidadeController> _logger;

        public CidadeController(ILogger<CidadeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<Cidade[]> Get()
        {
            var cidades = new List<Cidade>()
            {
                new Cidade
                {
                    UniqueId = new Guid("77e84f2f-bb7e-4048-80a9-dfd06eb0749b"),
                    Nome = "Belo horizonte"
                },
                new Cidade
                {
                    UniqueId = new Guid("77e84f2f-bb7e-4048-80a9-dfd06eb0749b"),
                    Nome = "Contagem"
                },
                new Cidade
                {
                    UniqueId = new Guid("77e84f2f-bb7e-4048-80a9-dfd06eb0749b"),
                    Nome = "Ribeirão das neves"
                },
                new Cidade
                {
                    UniqueId = new Guid("77e84f2f-bb7e-4048-80a9-dfd06eb0749b"),
                    Nome = "Santa luzia"
                }
            };

            System.Threading.Thread.Sleep(5000);

            return this.Ok(cidades);
        }


    }

    public class Cidade
    {
        public Guid UniqueId { get; set; }
        public string Nome { get; set; }
    }
}
