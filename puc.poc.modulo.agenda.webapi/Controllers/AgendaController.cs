using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace puc.poc.modulo.agenda.webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgendaController : ControllerBase
    {
        private readonly ILogger<AgendaController> _logger;

        public AgendaController(ILogger<AgendaController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post(string conveniado)
        {


            return this.Accepted();
        }

        public class ActionRequest
        {
            public string FieldA { get; set; }
            public string FieldB { get; set; }
            public string FieldC { get; set; }
        }
    }
}
