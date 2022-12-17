using Microsoft.AspNetCore.Diagnostics;
using MockInterview.Domain.Models;
using Serilog;
using System.Net;

namespace UtilityApi.Logs
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Log.Error($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new HttpResponse<string>
                        {
                            StatusCode = context.Response.StatusCode,
                            StatusMessage = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }
    }
}