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
        readonly BLL.DocumentDataBLL _ddbll = new();
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
        /// <summary>
        /// Forwards a query to the DocumentDataAPI, which gets a list of categories.
        /// </summary>
        /// <param name="limit">The maximum number of rows to get.</param>
        /// <param name="offset">The number of rows to skip (previous offset + previous limit).</param>
        /// <response code="200">Success: A JSON formatted response, containing categories from the Document Data Database.</response>
        /// <response code="500">Internal Server Error: A <see cref="ProblemDetails"/> describing the error.</response>
        [HttpGet] // 127.0.0.1:8081/api/document-data-api/categories
        [Route("/categories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<string>> GetAllCategories([FromQuery] int? limit, [FromQuery] int? offset)
        {
            try
            {
                return Ok(_ddbll.CategoriesBll(limit, offset));
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
        /// <summary>
        /// Forwards a query to the DocumentDataAPI, which gets a list of sources.
        /// </summary>
        /// <param name="limit">The maximum number of rows to get.</param>
        /// <param name="offset">The number of rows to skip (previous offset + previous limit).</param>
        /// <response code="200">Success: A JSON formatted response, containing sources from the Document Data Database.</response>
        /// <response code="500">Internal Server Error: A <see cref="ProblemDetails"/> describing the error.</response>
        [HttpGet] // 127.0.0.1:8081/api/document-data-api/sources
        [Route("/sources")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<string>> GetAllSources([FromQuery] int? limit, [FromQuery] int? offset)
        {
            try
            {
                return Ok(_ddbll.SourcesBll(limit, offset));
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