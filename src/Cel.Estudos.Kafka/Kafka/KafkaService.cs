using Cel.Estudos.Kafka.Configs;
using Cel.Estudos.Kafka.Interfaces;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Cel.Estudos.Kafka.Kafka
{
    public abstract class KafkaService<TMessage> : IDisposable, IKafkaService<TMessage> where TMessage : IMessage
    {
        private readonly KafkaSettings _kafkaSettings;
        private readonly string _topicName;
        private readonly IProducer<string, string> _producer;

        protected KafkaService(string topicName, IOptions<KafkaSettings> options,
            IKafkaProducerBuilder kafkaProducerBuilder)
        {
            _topicName = topicName;
            _kafkaSettings = options.Value;
            _producer = kafkaProducerBuilder.Build();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_producer != null)
                _producer.Dispose();
        }

        public async Task<Guid> SendAsync(TMessage message)
        {
            try
            {
                if (message.Key == Guid.Empty)
                    message.Key = Guid.NewGuid();

                if (_kafkaSettings.Active)
                {
                    await _producer.ProduceAsync(_topicName,
                       new Message<string, string>
                       {
                           Key = message.Key.ToString(),
                           Value = JsonConvert.SerializeObject(message)
                       }).ConfigureAwait(false);
                }

                return message.Key;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format(kafkaMessages.ErroComunicacao, ex.Message));
            }
        }

        public Task SendBatchAsync(IEnumerable<TMessage> messages)
        {
            throw new NotImplementedException();
        }
    }
}
