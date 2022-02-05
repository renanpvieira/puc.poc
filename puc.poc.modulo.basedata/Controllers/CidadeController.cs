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
                    UniqueId = 1,
                    Nome = "Belo horizonte"
                },
                new Cidade
                {
                    UniqueId = 2,
                    Nome = "Contagem"
                },
                new Cidade
                {
                    UniqueId = 3,
                    Nome = "Ribeirão das neves"
                },
                new Cidade
                {
                    UniqueId = 4,
                    Nome = "Santa luzia"
                }
            };

            System.Threading.Thread.Sleep(5000);

            return this.Ok(cidades);
        }


    }

    public class Cidade
    {
        public int UniqueId { get; set; }
        public string Nome { get; set; }
    }
}
