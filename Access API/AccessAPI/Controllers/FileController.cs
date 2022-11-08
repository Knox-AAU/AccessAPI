using Microsoft.AspNetCore.Mvc;
using Access_API.BLL;
using System.IO;

namespace Access_API.Controllers
{
    [Route("api/getpdf")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Knox filetransfer endpoints")]
    public class FileController : Controller
    {
        readonly FileBLL _fileBll = new();

        [HttpGet]
        public IActionResult Get([FromQuery] int id)
        {
            try
            {
                Stream stream = new MemoryStream(_fileBll.fileBLL(id).ToArray());
                return new FileStreamResult(stream, "application/pdf");
            }
            catch
            {
                return StatusCode(500);
            }

        }
    }
}
