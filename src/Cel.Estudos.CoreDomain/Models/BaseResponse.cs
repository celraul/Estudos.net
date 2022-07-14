namespace Cel.Estudos.CoreDomain.Models
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            Messages = new List<string>();
            CorrelationId = Guid.NewGuid();
        }

        public T? Data { get; set; }
        public Guid CorrelationId { get; set; }
        public IEnumerable<string> Messages { get; set; }
        public bool IsValid { get { return !Messages.Any(); } set { IsValid = value; } }

    }
}
