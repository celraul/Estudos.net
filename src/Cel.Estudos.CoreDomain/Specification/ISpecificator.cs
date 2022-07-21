namespace Cel.Estudos.CoreDomain.Specification
{
    public interface ISpecificator<T>
    {
        void Specify(T toSpecify, List<SpecificationBase<T>> specifications);
        bool Passed { get; }
    }
}
