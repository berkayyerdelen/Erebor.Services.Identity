using System;
using System.Net;
using System.Threading.Tasks;
using Erebor.Service.Identity.Infrastructure.Excetptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Erebor.Service.Identity.Api.Middlewares
{
    internal class ExceptionMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex) when (ex is NotFoundException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                var error = new ErrorModel
                {
                    Code = "404",
                    Message = ex.Message
                };
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(error));
            }
            catch (Exception ex) when (ex is InfrastructureException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                var error = new ErrorModel
                {
                    Code = "404",
                    Message = ex.Message
                };
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(error));
            }

            catch (Exception ex) when (ex is ApplicationException)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                var error = new ErrorModel
                {
                    Code = "00",
                    Message = ex.Message
                };

                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(error));
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;            
                var error = new ErrorModel
                {
                    Code = "00",
                    Message = ex.Message
                };

                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(error));
            }
        }
    }

    internal class ErrorModel
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
