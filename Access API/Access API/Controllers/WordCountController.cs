using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Access_API.Controllers
{
    [Route("api/dbstatus")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Knox WordCount endpoints")]
    public sealed class WordCountController : Controller
    {
        [Route("status")]
        public IActionResult GetStatus()
        {
            HttpWebResponse response = Drivers.HttpRequest.getRequest($"{Urls.WordCountUrl}/status");

            return StatusCode((int)response.StatusCode);
        }
    }
}