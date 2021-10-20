using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Access_API.BLL;

namespace Access_API.Controllers
{
    [Route("api/getpdf")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Knox filetransfer endpoints")]
    public class FileController : Controller
    {
        FileBLL fileBLL = new FileBLL();
        
        [HttpGet]
        public List<byte> Get([FromQuery] int id)
        {
            return fileBLL.fileBLL(id);
        }
    }
}
