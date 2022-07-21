using Cel.Estudos.CoreDomain.Specification;
using Cel.Estudos.Domain.Price.Entity;

namespace Cel.Estudos.Domain.Price.Specifications.CreateProductPrice
{
    internal class PriceShouldHaveValue : SpecificationBase<ProductPrice>
    {
        public override string Message => "Price should have value.";

        public override Func<ProductPrice, bool> Condition() =>
            value => value.Price > 0;
    }
}
