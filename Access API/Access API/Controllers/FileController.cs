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
        FileBLL fileBLL = new FileBLL();
        
        [HttpGet]
        public IActionResult Get([FromQuery] int id)
        {
            Stream stream = new MemoryStream(fileBLL.fileBLL(id).ToArray());
            return new FileStreamResult(stream, "application/pdf");
        }
    }
}
