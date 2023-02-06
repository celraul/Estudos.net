using Cel.Estudos.CoreDomain.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cel.Estudos.Api.Price.ActionFilters
{
    public class CorrelationIdActionFilter : IAsyncActionFilter
    {
        private readonly ICorrelationIdService _correlationIdService;


        public CorrelationIdActionFilter(ICorrelationIdService correlationIdService)
            => _correlationIdService = correlationIdService;


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string correlationId = context.HttpContext.Request.Headers["CorrelationId"];

            _correlationIdService.AddCorrelationId(correlationId);

            await next();
        }
    }
}
