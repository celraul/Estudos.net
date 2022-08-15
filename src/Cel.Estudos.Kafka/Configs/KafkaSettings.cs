namespace Cel.Estudos.Kafka.Configs
{
    public class KafkaSettings
    {
        public string Servers { get; set; }
        public string Acks { get; set; }
        public string TopicNameAdminPricing { get; set; }
        public bool Active { get; set; }
        public bool EnableIdempotence { get; set; }
    }
}