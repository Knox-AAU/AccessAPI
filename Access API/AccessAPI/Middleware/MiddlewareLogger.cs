using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

/*
* PURPOSE: Logs traffic through the Access API.
* Can be configured to log body by adding {text} as return parameter in GetResponse().
* RETURNS: Appends data to log.txt
* SOURCE: https://exceptionnotfound.net/using-middleware-to-log-requests-and-responses-in-asp-net-core/
*/

namespace Access_API.Middleware
{
    public class MiddlewareLogger
    {
        readonly string _path = AppDomain.CurrentDomain.BaseDirectory;
        static int _internalId = 0;
        private readonly RequestDelegate _next;

        public MiddlewareLogger(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            int id = _internalId++;
            await using StreamWriter file = new(_path + "Log.txt", append: true);
            string request = await GetRequest(context.Request); // Gets incoming request and formats it
            await file.WriteLineAsync($"ID: {id}, {request}");
            Stream bodyStream = context.Response.Body;

            using MemoryStream responseBody = new MemoryStream();

            context.Response.Body = responseBody;

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await file.WriteLineAsync($"ID: {id}, {request}, {ex}");
            }


            string response = await GetResponse(context.Response); // Gets response from server and formats it

            await file.WriteLineAsync($"ID: {id}, {response}");

            await responseBody.CopyToAsync(bodyStream);
        }

        private static async Task<string> GetRequest(HttpRequest request)
        {
            Stream body = request.Body;

            request.EnableBuffering();

            byte[] buffer = new byte[Convert.ToInt32(request.ContentLength)]; // creates a byte with the same length as the request stream

            await request.Body.ReadAsync(buffer.AsMemory(0, buffer.Length)).ConfigureAwait(false); // Copy request to the new buffer
            string bodyAsText = Encoding.UTF8.GetString(buffer);

            request.Body = body;

            return $"{request.HttpContext.Connection.RemoteIpAddress}, {DateTime.UtcNow}, {request.Path}, {bodyAsText}";
        }

        private static async Task<string> GetResponse(HttpResponse response)
        {

            response.Body.Seek(0, SeekOrigin.Begin); // Reads the response stream
            string text = await new StreamReader(response.Body).ReadToEndAsync();

            response.Body.Seek(0, SeekOrigin.Begin); // Resets the reader

            return $"{response.HttpContext.Connection.RemoteIpAddress}, {DateTime.UtcNow}, {response.StatusCode}, {response.HttpContext.Request.Path}";
        }
    }
}
