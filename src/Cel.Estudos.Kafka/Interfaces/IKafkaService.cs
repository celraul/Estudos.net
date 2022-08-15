namespace Cel.Estudos.Kafka.Interfaces
{
    public interface IKafkaService<TMessage>
    {
        Task<Guid> SendAsync(TMessage message);
        Task SendBatchAsync(IEnumerable<TMessage> messages);
    }
}
