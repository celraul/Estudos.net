namespace Cel.Estudos.CoreDomain.Notification
{
    public class Notification : INotification
    {
        public string Message { get; }

        protected Notification(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentException("Message can not be null or empty");

            Message = message;
        }
    }
}
