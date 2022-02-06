using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace puc.poc.modulo.filemanager.webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {

        private readonly ILogger<FileController> _logger;

        public FileController(ILogger<FileController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<File>> Get()
        {
            return this.Ok(GetFiles());
        }


        private List<File> GetFiles()
        {
            return new List<File>()
            {
                new File{UniqueId = "51fdb554623de0dbe71b567x", Nome = "Exame sangue", FileName = "sangue.pdf"},
                new File{UniqueId = "91fdb554623de0dbe71b568w", Nome = "Endoscopia", FileName = "endo.pdf"},
            };
        }
    }

    public class File
    {
        public string UniqueId { get; set; }

        public string FileName { get; set; }
        public string Nome { get; set; }
    }
}
