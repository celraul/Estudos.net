﻿using Cel.Estudos.Application.Price.Commands;
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
        public async Task<ActionResult> Post(CreatePriceCommand command)
        {
            var response = _mediator.Send(command);

            return CreateOkResponseOrBadRequestIfHasNotifications(response);
        }
    }
}