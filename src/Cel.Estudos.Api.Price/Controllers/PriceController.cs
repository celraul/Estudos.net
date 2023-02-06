using Cel.Estudos.Api.Price.ActionFilters;
using Cel.Estudos.Application.Price.Commands;
using Cel.Estudos.CoreDomain.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cel.Estudos.Api.Price.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PriceController(INotificationContext notificationContext, IMediator mediator) : base(notificationContext)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ServiceFilter(typeof(CorrelationIdActionFilter))]
        public async Task<ActionResult> Post(CreateProductPriceCommand command) =>
             CreateOkResponseOrBadRequestIfHasNotifications(await _mediator.Send(command));

    }
}
