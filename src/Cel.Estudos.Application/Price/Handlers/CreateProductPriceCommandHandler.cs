using Cel.Estudos.Application.Price.Commands;
using Cel.Estudos.Application.Price.Events;
using Cel.Estudos.CoreDomain.Notification;
using Cel.Estudos.CoreDomain.Specification;
using Cel.Estudos.Domain.Price.Entity;
using Cel.Estudos.Domain.Price.Repositories;
using Cel.Estudos.Domain.Price.Specifications.CreateProductPrice;
using Cel.Estudos.Infra.Data.Data;
using FluentValidation;
using MediatR;

namespace Cel.Estudos.Application.Price.Handlers;

public class CreateProductPriceCommandHandler : IRequestHandler<CreateProductPriceCommand, bool>
{
    private readonly INotificationContext _notificationContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateProductPriceCommand> _validator;
    private readonly ISpecificator<ProductPrice> _productPriceSpecificator;
    private readonly IProductPriceRepository _priceRepository;
    private readonly IMediator _mediator;

    public CreateProductPriceCommandHandler(INotificationContext notificationContext,
                                            IUnitOfWork unitOfWork,
                                            IValidator<CreateProductPriceCommand> validator,
                                            ISpecificator<ProductPrice> productPriceSpecificator,
                                            IProductPriceRepository priceRepository,
                                            IMediator mediator)
    {
        _notificationContext = notificationContext;
        _unitOfWork = unitOfWork;
        _validator = validator;
        _productPriceSpecificator = productPriceSpecificator;
        _priceRepository = priceRepository;
        _mediator = mediator;
    }

    public async Task<bool> Handle(CreateProductPriceCommand request, CancellationToken cancellationToken)
    {
        var validator = await _validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
        if (!validator.IsValid)
            return false;

        var productPrice = new ProductPrice(request.IdProduct,
                                            request.Price,
                                            request.PriceCost);

        _productPriceSpecificator.Specify(productPrice, new CreateProductPriceSpecification());
        if (!_productPriceSpecificator.Passed)
            return false;

        productPrice.AddEvents(new ProductPriceCreatedEvent(productPrice.IdProduct,
                                                    productPrice.Price,
                                                    request.CorrelationId));

        _unitOfWork.BeginTransaction();

        await _priceRepository.Save(productPrice);

        _unitOfWork.Commit();

        foreach (var productPriceEvents in productPrice.Events)
            await _mediator.Publish(productPriceEvents);

        return true;
    }
}