using Cel.Estudos.Application.Price.Commands;
using Cel.Estudos.CoreDomain.Notification;
using Cel.Estudos.Domain.Price.Entity;
using Cel.Estudos.Domain.Price.Repositories;
using Cel.Estudos.Infra.Data.Data;
using FluentValidation;
using MediatR;

namespace Cel.Estudos.Application.Price.Handlers
{
    public class CreatePriceCommandHandler : IRequestHandler<CreatePriceCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreatePriceCommand> _validator;
        private readonly INotificationContext _notificationContext;
        private readonly IPriceRepository _priceRepository;

        public CreatePriceCommandHandler(IUnitOfWork unitOfWork,
                                         IPriceRepository priceRepository,
                                         IValidator<CreatePriceCommand> validator,
                                         INotificationContext notificationContext)
        {
            _unitOfWork = unitOfWork;
            _priceRepository = priceRepository;
            _validator = validator;
            _notificationContext = notificationContext;
        }

        public async Task<bool> Handle(CreatePriceCommand request, CancellationToken cancellationToken)
        {
            var validator = await _validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!validator.IsValid)
                return false;

            _unitOfWork.BeginTransaction();

            // usar factory

            await _priceRepository.Save(new Product());

            _unitOfWork.Commit();

            return true;
        }
    }
}
