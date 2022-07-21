namespace Cel.Estudos.CoreDomain.Specification.Common
{
    public class DecimalShouldHaveValue : SpecificationBase<decimal>
    {
        public override string Message => "";

        public override Func<decimal, bool> Condition() =>
            value => value > 0;
    }
}
