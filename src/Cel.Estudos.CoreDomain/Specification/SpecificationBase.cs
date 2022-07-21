namespace Cel.Estudos.CoreDomain.Specification
{
    public abstract class SpecificationBase<T>
    {
        public abstract string Message { get; }
        public abstract Func<T, bool> Condition();
    }
}
