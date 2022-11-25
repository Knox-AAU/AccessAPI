using System;
using System.Collections.Generic;
using System.Net.Mime;
using Access_API.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Access_API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(GroupName = "Knox search endpoints")]
    [Route("api/search")]
    [Produces(MediaTypeNames.Application.Json)]
    public class SearchController : ControllerBase
    {
        readonly BLL.SearchBLL _sb = new();

        /// <summary>
        /// Forwards a search query to the DocumentDataAPI with the given arguments.
        /// </summary>
        /// <param name="words">A comma-separated list of words.</param>
        /// <param name="sourceIds">A list of source IDs used to delimit the search.</param>
        /// <param name="authors">The names of authors, used to delimit the search.</param>
        /// <param name="categoryIds">The IDs of categories, used to delimit the search.</param>
        /// <param name="beforeDate">A minimum date for documents.</param>
        /// <param name="afterDate">A maximum date for documents.</param>
        /// <param name="limit">The maximum number of rows to get.</param>
        /// <param name="offset">The number of rows to skip (previous offset + previous limit).</param>
        /// <response code="200">Success: A JSON formatted response, containing the search results that match the query.</response>
        /// <response code="500">Internal Server Error: A <see cref="ProblemDetails"/> describing the error.</response>
        [HttpGet] // 127.0.0.1:8081/api/search?words=test&sourceId=1&author=bob&categoryId=2
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<string> Get([FromQuery] string words, [FromQuery] List<long> sourceIds,
            [FromQuery] List<string> authors,
            [FromQuery] List<int> categoryIds, DateTime? beforeDate, DateTime? afterDate,
            int? limit, int? offset)
        {
            try
            {
                return Content(
                    _sb.SearchBll(words, sourceIds, authors, categoryIds, beforeDate, afterDate, limit, offset),
                    MediaTypeNames.Application.Json);
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
