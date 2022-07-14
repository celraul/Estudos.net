using Cel.Estudos.CoreDomain.Models;
using Cel.Estudos.CoreDomain.Notification;
using Microsoft.AspNetCore.Mvc;

namespace Cel.Estudos.Api.Price.Controllers
{
    public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        protected readonly INotificationContext _notificationContext;

        public ControllerBase(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        protected ActionResult CreateOkResponseOrBadRequestIfHasNotifications(object result)
        {
            var response = new BaseResponse<object>();
            response.Data = result;

            if (_notificationContext.HasNotifications)
            {
                response.Messages = _notificationContext.GetAll().Select(x => x.Message);
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}