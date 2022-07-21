using Cel.Estudos.CoreDomain.Notification;
using System.Net.Mime;
using System.Text.Json;

namespace Cel.Estudos.Api.Price.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

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
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int code = StatusCodes.Status400BadRequest;

            var response = new
            {
                Error = $"Ocorreu um erro: {exception.Message}",
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