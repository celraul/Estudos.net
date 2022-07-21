using Cel.Estudos.CoreDomain.Events;

namespace Cel.Estudos.CoreDomain.Entity
{
    public class BaseEntity : IEventGenerator
    {
        public BaseEntity()
        {
            Events = new List<Event>();

            CreateDate = DateTime.UtcNow;
            UpdateDate = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public DateTime CreateDate { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public List<Event> Events { get; private set; }

        public void AddEvents(Event @event) => Events.Add(@event);
    }
}