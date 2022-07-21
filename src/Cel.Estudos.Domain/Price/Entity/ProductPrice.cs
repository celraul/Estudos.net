using Cel.Estudos.CoreDomain.Entity;
using System.Diagnostics.CodeAnalysis;

namespace Cel.Estudos.Domain.Price.Entity
{
    public class ProductPrice : BaseEntity
    {
        public ProductPrice(int idProduct, decimal price, decimal priceCost)
        {
            IdProduct = idProduct;
            Price = price;
            PriceCost = priceCost;
        }

        public int IdProduct { get; private set; }
        [NotNull, DisallowNull] public decimal Price { get; private set; }
        public decimal PriceCost { get; private set; }
    }
}