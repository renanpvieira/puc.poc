using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace puc.poc.modulo.webapp.Pages.ColaboradorLogado
{
    public class IniciarAtendimentoModel : PageModel
    {
        [BindProperty]
        public Associado Associado { get; set; } = new Associado();

        [BindProperty]
        public List<File> Files { get; set; } = new List<File>();

        [BindProperty]
        public List<Servico> Servicos { get; set; } = new List<Servico>();

        public async Task OnGet()
        {
            var associado = Request.Query["associado"];

            using var client = new HttpClient();
            

            var responseAss = await client.GetAsync($"http://localhost:1565/api/Associado?uniqueId={associado}");
            var respAss = await responseAss.Content.ReadAsStringAsync();
            Associado = JsonConvert.DeserializeObject<Associado>(respAss);

            var responseFile = await client.GetAsync($"https://localhost:44331/File");
            var respFile = await responseFile.Content.ReadAsStringAsync();
            Files = JsonConvert.DeserializeObject<List<File>>(respFile);

            var responseServico = await client.GetAsync($"https://localhost:44373/Servico?tipo=CLI");
            var respServico = await responseServico.Content.ReadAsStringAsync();
            Servicos = JsonConvert.DeserializeObject<List<Servico>>(respServico);
        }
    }

    public class File
    {
        public string UniqueId { get; set; }

        public string Nome { get; set; }

        public string FileName { get; set; }
    }

    public class Servico
    {
        public string UniqueId { get; set; }

        public string Descricao { get; set; }

        public string Tipo { get; set; }
    }
}



