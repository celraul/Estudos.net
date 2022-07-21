using Cel.Estudos.CoreDomain.Events;

namespace Cel.Estudos.Application.Price.Events
{
    public class ProductPriceCreatedEvent : Event
    {
        public int IdProduct { get; private set; }
        public decimal Price { get; private set; }

        public ProductPriceCreatedEvent(int idProduct, decimal price, Guid correlationId) : base(correlationId)
        {
            IdProduct = idProduct;
            Price = price;
        }
    }
}
