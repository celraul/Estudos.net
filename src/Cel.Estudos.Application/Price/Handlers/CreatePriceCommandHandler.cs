using Cel.Estudos.Application.Price.Commands;
using Cel.Estudos.CoreDomain.Notification;
using FluentValidation;
using MediatR;

namespace Cel.Estudos.Application.Price.Handlers
{
    public class CreatePriceCommandHandler : IRequestHandler<CreatePriceCommand, bool>
    {
        private readonly IValidator<CreatePriceCommand> _validator;
        private readonly INotificationContext _notificationContext;

        public CreatePriceCommandHandler(IValidator<CreatePriceCommand> validator,
            INotificationContext notificationContext)
        {
            _validator = validator;
            _notificationContext = notificationContext;
        }

        public async Task<bool> Handle(CreatePriceCommand request, CancellationToken cancellationToken)
        {
            if (_notificationContext.HasNotifications)
                return false;

            var validator = await _validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!validator.IsValid)
                return false;

            return true;
        }
    }
}
