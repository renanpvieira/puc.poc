using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace puc.poc.modulo.conveniado.webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConveniadoController : ControllerBase
    {

        private readonly ILogger<ConveniadoController> _logger;

        public ConveniadoController(ILogger<ConveniadoController> logger)
        {
            _logger = logger;
        }

        [HttpGet("lista")]
        public ActionResult<IEnumerable<Conveniado>> Get(string cidade, string especialidade)
        {
            var conveniados = GetConveniados();


           var filtro = conveniados
               .Where(x => 
                   x.Especialidades.Any(x => x.Id == especialidade) && 
                   x.Enderecos.Any(x => x.Cidade.UniqueId.ToString() == cidade))
               .ToArray();
            
           return this.Ok(filtro);
        }

        [HttpGet("id")]
        public ActionResult<Conveniado> Get(string uniqueid)
        {
            var conveniados = GetConveniados();
            
            var filtro = conveniados
                .Where(x => x.UniqueId == uniqueid)
                .FirstOrDefault();

            return this.Ok(filtro);
        }


        List<Conveniado> GetConveniados()
        {
            return new List<Conveniado>
            {
                new Conveniado
                {
                    UniqueId = "61fdb554623de0dbe71b568y",
                    Nome = "Laboratório Vieira",
                    Enderecos = new List<Endereco>
                    {
                        new Endereco
                        {
                            Logradouro = "Rua 1",
                            Numero = "1",
                            Bairro = "Bairro 1",
                            Cidade = new Cidade{UniqueId = 1, Nome = "Belo horizonte"}
                        }
                    },
                    Especialidades = new List<Especialidade>
                    {
                        new Especialidade { Id = "61fdb554623de0dbe71b5689" },
                        new Especialidade { Id = "61fdb554623de0dbe71b568a" },
                    }
                },
                new Conveniado
                {
                    UniqueId = "61fdb554623de0dbe71b568x",
                    Nome = "Laboratório Minas",
                    Enderecos = new List<Endereco>
                    {
                        new Endereco
                        {
                            Logradouro = "Rua 2",
                            Numero = "2",
                            Bairro = "Bairro 2",
                            Cidade = new Cidade{UniqueId = 2, Nome = "Contagem"}
                        }
                    },
                    Especialidades = new List<Especialidade>
                    {
                        new Especialidade { Id = "61fdb554623de0dbe71b5689" },
                        new Especialidade { Id = "61fdb554623de0dbe71b568b" },
                    }
                }
            };
        }

    }




    public class Conveniado
    {
        public string UniqueId { get; set; }

        public string Nome { get; set; }

        public List<Endereco> Enderecos { get; set; }

        public List<Especialidade> Especialidades { get; set; }
    }

    public class Endereco
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public Cidade Cidade { get; set; }
    }

    public class Cidade
    {
        public int UniqueId { get; set; }
        public string Nome { get; set; }
    }

    public class Especialidade
    {
        public string Id { get; set; }
    }
}
