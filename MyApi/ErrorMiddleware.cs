using System.Net;
using Newtonsoft.Json;

namespace MyApi.Middleware
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorMiddleware> _logger;

        public ErrorMiddleware(RequestDelegate next, ILogger<ErrorMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var error = JsonConvert.SerializeObject(new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = $"{ex.Message} {ex.InnerException?.Message}",
                    InnerMessage = ex.InnerException?.Message,
                    Path = context.Request.Path,
                    TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                });

                await context.Response.WriteAsync(error);
            }
        }
    }

}