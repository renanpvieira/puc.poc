using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace puc.poc.modulo.webapp.Pages.AdminLogado
{
    public class BuscaAssociadoModel : PageModel
    {

        [BindProperty] 
        public List<Associado> Associados { get; set; } = new List<Associado>();

        public async Task OnGet()
        {
            using var client = new HttpClient();

            var response = await client.GetAsync("http://localhost:1565/api/Associado/buscar");
            var resp = await response.Content.ReadAsStringAsync();

            Associados = JsonConvert.DeserializeObject<List<Associado>>(resp);
        }
    }

    public class Associado
    {
        public string UniqueId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
    }
}
