using System;
using CodeJam;
using GMBAcademy.Web.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GMBAcademy.Web
{
    public static class ExceptionHandlerMiddleware
    {
        public static IApplicationBuilder UseExceptionHandler(this IApplicationBuilder app,
            IHostingEnvironment environment, ILogger logger)
        {
            return app.Use(async (context, func) =>
            {
                try
                {
                    await func();
                }
                catch (BadRequestException e)
                {
                    logger.LogWarning(e.Message);
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = 400;

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                        { errorCode = 400, success = false, Error = e.Message }));
                }
                catch (DomainException e)
                {
                    logger.LogWarning(e.Message);
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = 408;

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                        { errorCode = 408, success = false, Error = e.Message }));

                }
                catch (Exception e)
                {
                    logger.LogError(e.ToDiagnosticString());
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = 500;

                    await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                        { errorCode = 500, success = false, Error = "Unexpected error", Message = e.Message }));
                }
            });
        }
    }
}
