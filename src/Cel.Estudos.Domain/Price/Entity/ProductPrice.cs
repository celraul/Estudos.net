using Cel.Estudos.CoreDomain.Entity;

namespace Cel.Estudos.Domain.Price.Entity
{
    public class ProductPrice : BaseEntity
    {
        public int IdProduct { get; set; }
        public decimal Price { get; set; }
        public decimal PriceCost { get; set; }
    }
}