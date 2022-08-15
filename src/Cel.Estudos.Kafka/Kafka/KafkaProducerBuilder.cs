using Cel.Estudos.Kafka.Configs;
using Cel.Estudos.Kafka.Interfaces;
using Confluent.Kafka;
using Microsoft.Extensions.Options;

namespace Cel.Estudos.Kafka.Kafka
{
    public class KafkaProducerBuilder : IKafkaProducerBuilder
    {
        private readonly KafkaSettings _kafkaSettings;

        public KafkaProducerBuilder(IOptions<KafkaSettings> options)
        {
            _kafkaSettings = options.Value;
        }

        public IProducer<string, string> Build()
        {
            return new ProducerBuilder<string, string>(new ProducerConfig
            {
                EnableIdempotence = _kafkaSettings.EnableIdempotence,
                BootstrapServers = _kafkaSettings.Servers,
                Acks = Acks.All // Aguarda até a mensagem ser replicada.
            }).Build();
        }
    }
}
