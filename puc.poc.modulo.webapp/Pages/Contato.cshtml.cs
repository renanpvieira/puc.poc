using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace puc.poc.modulo.webapp.Pages
{
    [ValidateAntiForgeryToken]
    public class ContatoModel : PageModel
    {
        public void OnGet()
        {
        }

        
        public void OnPost()
        {
            var nome = Request.Form["nome"];
            var email = Request.Form["email"];
            var texto = Request.Form["texto"];

        }
    }
}
