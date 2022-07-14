namespace Cel.Estudos.CoreDomain.Command
{
    public interface ICommand
    {
        Guid CorrelationId { get; set; }
    }
}
