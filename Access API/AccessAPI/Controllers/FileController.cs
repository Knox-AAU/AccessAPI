using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Access_API.BLL;
using System.IO;

namespace Access_API.Controllers
{
    [Route("api/getpdf")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Knox filetransfer endpoints")]
    public class FileController : Controller
    {
        readonly FileBLL fileBLL = new();

        [HttpGet]
        public IActionResult Get([FromQuery] int id)
        {
            try
            {
                Stream stream = new MemoryStream(fileBLL.fileBLL(id).ToArray());
                return new FileStreamResult(stream, "application/pdf");
            }
            catch
            {
                return StatusCode(500);
            }

        }
    }
}
