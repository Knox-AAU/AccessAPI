using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Access_API.Controllers
{
    [Route("api/document-data-api")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Knox DocumentDataAPI endpoints")]
    public sealed class DocumentDataController : Controller
    {
        /// <summary>
        /// Probes the DocumentDataAPI to check if a connection can be established to the database.
        /// </summary>
        /// <response code="200">Success: The database is reachable.</response>
        /// <response code="500">Internal Server Error: A <see cref="ProblemDetails"/> describing the error.</response>
        [HttpGet]
        [Route("status")]
        public IActionResult GetStatus()
        {
            HttpWebResponse response = Drivers.HttpRequest.GetRequest($"{Urls.DocumentDataUrl}/status");

            return StatusCode((int) response.StatusCode);
        }
    }
}
