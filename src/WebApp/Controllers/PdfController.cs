using System.Net.Mime;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Spire.Doc;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly IHostEnvironment _hostEnvironment;

        public PdfController(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        [Route("download/{nome}")]
        public ActionResult Download([FromRoute]string nome)
        {
            var path = _hostEnvironment.ContentRootPath;


            var document = new Document();
            document.LoadFromFile(@$"{path}/Templates/Eu.docx");

            document.Replace("@nome", nome, true, true);

            var stream = new MemoryStream();
            document.SaveToStream(stream, FileFormat.PDF);

            var bytes = stream.ToArray();
            return File(bytes, MediaTypeNames.Application.Pdf);
        }
    }
}
