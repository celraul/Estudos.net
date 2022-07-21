using Cel.Estudos.CoreDomain.Specification;
using Cel.Estudos.Domain.Price.Entity;

namespace Cel.Estudos.Domain.Price.Specifications.CreateProductPrice
{
    internal class PriceCostShouldHaveValue : SpecificationBase<ProductPrice>
    {
        public override string Message => "Price cost should have value.";

        public override Func<ProductPrice, bool> Condition() =>
            value => value.PriceCost > 0;
    }
}
