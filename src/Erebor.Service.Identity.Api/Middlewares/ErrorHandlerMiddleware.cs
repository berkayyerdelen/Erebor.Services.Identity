using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Erebor.Service.Identity.Api.Middlewares
{
    internal class ErrorHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                var statusCode = 500;
                var code = "error";
                var message = "There was an error";
                _logger.LogError(exception, exception.Message);
                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsJsonAsync(new {code, message});
            }
        }
    }
}