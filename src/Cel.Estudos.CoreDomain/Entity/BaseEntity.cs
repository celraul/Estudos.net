using Cel.Estudos.CoreDomain.Events;

namespace Cel.Estudos.CoreDomain.Entity
{
    public class BaseEntity : IEventGenerator
    {
        public BaseEntity()
        {
            Events = new List<Event>();
        }

        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public List<Event> Events { get; set; }
    }
}