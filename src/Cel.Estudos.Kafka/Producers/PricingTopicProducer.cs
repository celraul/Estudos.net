using Cel.Estudos.Kafka.Configs;
using Cel.Estudos.Kafka.Interfaces;
using Cel.Estudos.Kafka.Kafka;
using Cel.Estudos.Kafka.Topicos;
using Microsoft.Extensions.Options;

namespace Cel.Estudos.Kafka.Producers
{
    public class PricingTopicProducer : KafkaService<PricingTopic>, IPricingTopicProducer
    {
        public PricingTopicProducer(IOptions<KafkaSettings> options, IKafkaProducerBuilder kafkaProducerBuilder)
            : base(options.Value.TopicNameAdminPricing, options, kafkaProducerBuilder)
        {
        }
    }
}
