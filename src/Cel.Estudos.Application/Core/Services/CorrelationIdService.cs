using Cel.Estudos.CoreDomain.Services;

namespace Cel.Estudos.Application.Core.Services;

public class CorrelationIdService : ICorrelationIdService
{
    public string CorrelationId => _correlationId;

    public string _correlationId { get; set; } = null!;

    public void AddCorrelationId(string correlationId)
        => _correlationId = correlationId;

}
