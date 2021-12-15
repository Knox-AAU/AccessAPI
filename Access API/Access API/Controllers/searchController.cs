using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Access_API.Controllers
{
    [Route("api/search")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Knox search endpoints")]
    public class SearchController : ControllerBase
    {
        BLL.SearchBLL sb = new BLL.SearchBLL();
        [HttpGet]       // 127.0.0.1:8081/api/search?input=test&sources=Nordjyske,Grundfoss
        public string Get([FromQuery] string input, [FromQuery] string sources)
        {
            string result = string.Empty;
            try
            {
                result = JsonConvert.SerializeObject(sb.searchBLL(input, sources));
                HttpContext.Response.StatusCode = 200;
            }
            catch
            {
                HttpContext.Response.StatusCode = 500;
            }
            return result;
        }
    }
}
