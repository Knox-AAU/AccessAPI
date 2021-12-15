using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Access_API.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]       // 127.0.0.1:8081/api/search?input=test&sources=Nordjyske,Grundfoss
        public IActionResult Get()
        {
            byte[] bytes = System.IO.File.ReadAllBytes("D:\\solutions.pdf");
            Stream stream = new MemoryStream(bytes);
            return new FileStreamResult(stream, "application/pdf");

        }
        [Route("WaitInMs")]
        [HttpGet]
        public void WaitInMs(int milliseconds)
        {
            DateTime dateTime = DateTime.UtcNow;
            TimeSpan ts = new(0, 0, 0, 0, milliseconds);
            while (DateTime.UtcNow - dateTime <= ts) ;
            HttpContext.Response.StatusCode = 200;
        }

    }
}
