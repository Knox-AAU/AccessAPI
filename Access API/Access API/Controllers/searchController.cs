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
    [Route("[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Knox search endpoints")]
    public class searchController : ControllerBase
    {
        [HttpGet]       // 127.0.0.1:8081/api/search?input=test&sources=Nordjyske,Grundfoss
        public string Get([FromQuery] string input, [FromQuery] string sources)
        {
            BLL.SearchBLL sb = new BLL.SearchBLL();
            string result = JsonConvert.SerializeObject(sb.searchBLL(input, sources));

            return result; 
        }
    }

    
}


