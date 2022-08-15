using Confluent.Kafka;

namespace Cel.Estudos.Kafka.Interfaces
{
    public interface IKafkaProducerBuilder
    {
        IProducer<string, string> Build();
    }
}
