using System.Diagnostics;

using Microsoft.AspNetCore.Diagnostics;

namespace AttendanceManagementSystem.Api.Extensions;

public static class ErrorHandlingExtensions
{
    public static void ConfigureExceptionHanlder(this IApplicationBuilder app)
    {
        app.Run(async context =>
        {
            var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
            var exceptionDetails = context.Features.Get<IExceptionHandlerFeature>();
            var exception = exceptionDetails?.Error;

            logger.LogError(
                exception,
                @$"Could Not Process a request in
                    Machine {Environment.MachineName},
                    TraceId: {Activity.Current?.Id}"
            );

            await Results.Problem(
                title: "We Made a Mistake but we are working in it",
                statusCode: StatusCodes.Status500InternalServerError,
                extensions: new Dictionary<string, object?>
                {
                {"TraceId", Activity.Current?.Id}
                }
            ).ExecuteAsync(context);
        });
    }
}