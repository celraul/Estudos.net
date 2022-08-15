using Cel.Estudos.Kafka.Interfaces;

namespace Cel.Estudos.Kafka.Topicos
{
    public class PricingTopic : IMessage
    {
        public Guid Key { get; set; }
        public decimal PrecoVenda { get; set; }
    }
}
