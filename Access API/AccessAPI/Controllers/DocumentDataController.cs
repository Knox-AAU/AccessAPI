using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Access_API.Controllers
{
    [Route("api/document-data-api")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Knox DocumentDataAPI endpoints")]
    public sealed class DocumentDataController : Controller
    {
        [HttpGet]
        [Route("status")]
        public IActionResult GetStatus()
        {
            HttpWebResponse response = Drivers.HttpRequest.GetRequest($"{Urls.DocumentDataUrl}/status");

            return StatusCode((int)response.StatusCode);
        }
    }
}
