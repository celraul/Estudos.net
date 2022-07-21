using Cel.Estudos.CoreDomain.Events;

namespace Cel.Estudos.CoreDomain
{
    public interface IEventGenerator
    {
        List<Event> Events { get; set; }
    }
}
