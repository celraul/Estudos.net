namespace Cel.Estudos.CoreDomain.Events
{
    public class Event : Message, MediatR.INotification
    {
        public DateTime DateExecution { get; private set; }
        public Guid CorrelationId { get; set; }

        public Event(Guid correlationId)
        {
            DateExecution = DateTime.UtcNow;
            CorrelationId = correlationId;
        }
    }
}