using Cel.Estudos.Application.Price.Events;
using MediatR;

namespace Cel.Estudos.Application.Price.Handlers
{
    internal class ProductPriceCreatedEventHandler : INotificationHandler<ProductPriceCreatedEvent>
    {
        public Task Handle(ProductPriceCreatedEvent notification, CancellationToken cancellationToken)
        {
            // TODO evento para salvar no mongo
            return Task.CompletedTask;
        }
    }
}
