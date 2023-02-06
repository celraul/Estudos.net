namespace Cel.Estudos.CoreDomain.Services;

public interface ICorrelationIdService
{
    string CorrelationId { get; }
    void AddCorrelationId(string correlationId);
}
