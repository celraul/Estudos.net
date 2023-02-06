using Cel.Estudos.Lib;
using System.Net.Mime;
using System.Text.Json;

namespace Cel.Estudos.Api.Price.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private const string DefaultMessageError = "Unknown error.";
        private const string SqlDefaultMessageError = "Error on execute Db command.";

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (SqlException ex)
            {
                await HandleExceptionAsync(httpContext, ex, SqlDefaultMessageError);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, string message = DefaultMessageError)
        {
            int code = StatusCodes.Status500InternalServerError;

            var response = new
            {
                Error = message,
                ErrorDetails = exception.Message,
                ErrorCode = code
            };

            var responseJson = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = code;

            await context.Response.WriteAsync(responseJson);
        }
    }
}