using Ebebul.Core.DTOs;
using Ebebul.Service.Exceptions;
using Ebebul.Service.Exeptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Ebebul.API.Middlewares
{
    public static class UseCustomExecptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {

                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException=>404,

                        _ => 500
                        //default
                    };
                    context.Response.StatusCode = statusCode;
                    
                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
