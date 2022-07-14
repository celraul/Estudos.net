namespace Cel.Estudos.CoreDomain.Notification
{
    public class NotificationContext : INotificationContext
    {
        private readonly List<INotification> Notifications;
        public bool HasNotifications => Notifications.Any();

        public NotificationContext()
        {
            Notifications = new List<INotification>();
        }

        public void Add(INotification notification)
        {
            Notifications.Add(notification);
        }

        public void AddRange(IEnumerable<INotification> notifications)
        {
            Notifications.AddRange(notifications);
        }

        public IReadOnlyList<INotification> GetAll() => Notifications;
    }
}
