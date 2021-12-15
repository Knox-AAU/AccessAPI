using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Access_API.Controllers
{
    [Route("api/wordCount")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Knox WordCount endpoints")]
    public sealed class WordCountController : Controller
    {
        [HttpGet]
        [Route("status")]
        public IActionResult GetStatus()
        {
            HttpWebResponse response = Drivers.HttpRequest.GetRequest($"{Urls.WordCountUrl}/status");

            return StatusCode((int)response.StatusCode);
        }
    }
}