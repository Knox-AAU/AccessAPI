using System;
using System.Collections.Generic;
using System.Net;
using Access_API.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Access_API.Controllers
{
    [Route("api/document-data-api")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Knox DocumentDataAPI endpoints")]
    public sealed class DocumentDataController : Controller
    {
        readonly BLL.SearchBLL _sb = new();
        
        /// <summary>
        /// Probes the DocumentDataAPI to check if a connection can be established to the database.
        /// </summary>
        /// <response code="200">Success: The database is reachable.</response>
        /// <response code="500">Internal Server Error: A <see cref="ProblemDetails"/> describing the error.</response>
        [HttpGet]
        [Route("/status")]
        public IActionResult GetStatus()
        {
            HttpWebResponse response = Drivers.HttpRequest.GetRequest($"{Urls.DocumentDataUrl}/status");

            return StatusCode((int)response.StatusCode);
        }
        
        [HttpGet] // 127.0.0.1:8081/api/document-data-api/categories
        [Route("/categories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<string>> GetAllCategories([FromQuery] int? limit, [FromQuery] int? offset)
        {
            try
            {
                return Ok(_sb.CategoriesBll(limit, offset));
            }
            catch (ApiResponseException e)
            {
                return Problem(e.ErrorResponse.Title);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        
        [HttpGet] // 127.0.0.1:8081/api/document-data-api/sources
        [Route("/sources")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<string>> GetAllSources([FromQuery] int? limit, [FromQuery] int? offset)
        {
            try
            {
                return Ok(_sb.SourcesBll(limit, offset));
            }
            catch (ApiResponseException e)
            {
                return Problem(e.ErrorResponse.Title);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
