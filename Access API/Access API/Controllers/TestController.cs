using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Access_API.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]       // 127.0.0.1:8081/api/search?input=test&sources=Nordjyske,Grundfoss
        public string Get()
        {
            return "{" +
   "\"result\":[" +
      "{" +
                "\"title\":\"Sine blev sendt i kræftbehandling på Rigshospitalet. Hun kom glad hjem igen\"," +
         "\"filepath\":\"/mnt/data/srv/data/newsarchive/2020-12-04/TabletXML/00_12_2-_sektion_fre_s012_02_nordjyll_0412_202012040000_1014942548.xml\"," +
        "\"score\":0.579903985789051" +
      "}" +
   "]" +
"}";
        }
    }
}
