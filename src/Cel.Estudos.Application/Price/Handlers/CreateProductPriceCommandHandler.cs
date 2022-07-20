using Cel.Estudos.Application.Price.Commands;
using Cel.Estudos.CoreDomain.Notification;
using Cel.Estudos.Domain.Price.Entity;
using Cel.Estudos.Domain.Price.Repositories;
using Cel.Estudos.Infra.Data.Data;
using FluentValidation;
using MediatR;

namespace Cel.Estudos.Application.Price.Handlers
{
    public class CreateProductPriceCommandHandler : IRequestHandler<CreateProductPriceCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateProductPriceCommand> _validator;
        private readonly INotificationContext _notificationContext;
        private readonly IProductPriceRepository _priceRepository;

        public CreateProductPriceCommandHandler(IUnitOfWork unitOfWork,
                                         IProductPriceRepository priceRepository,
                                         IValidator<CreateProductPriceCommand> validator,
                                         INotificationContext notificationContext)
        {
            _unitOfWork = unitOfWork;
            _priceRepository = priceRepository;
            _validator = validator;
            _notificationContext = notificationContext;
        }

        public async Task<bool> Handle(CreateProductPriceCommand request, CancellationToken cancellationToken)
        {
            var validator = await _validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!validator.IsValid)
                return false;

            _unitOfWork.BeginTransaction();

            // usar factory

            await _priceRepository.Save(new ProductPrice
            {
                Price = request.Price.Value,
                PriceCost = request.PriceCost.Value,
                IdProduct = request.IdProduct
            });

            _unitOfWork.Commit();

            return true;
        }
    }
}
