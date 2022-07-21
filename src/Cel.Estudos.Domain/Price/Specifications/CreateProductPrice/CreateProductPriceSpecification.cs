using Cel.Estudos.CoreDomain.Specification;
using Cel.Estudos.Domain.Price.Entity;

namespace Cel.Estudos.Domain.Price.Specifications.CreateProductPrice
{
    public class CreateProductPriceSpecification : List<SpecificationBase<ProductPrice>>
    {
        public CreateProductPriceSpecification()
        {
            AddRange(new List<SpecificationBase<ProductPrice>>() {
                new PriceShouldHaveValue(),
                new PriceCostShouldHaveValue()
            });
        }
    }
}
