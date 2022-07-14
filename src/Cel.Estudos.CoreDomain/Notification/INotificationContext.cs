namespace Cel.Estudos.CoreDomain.Notification
{
    public interface INotificationContext
    {
        bool HasNotifications { get; }
        void Add(INotification notification);
        void AddRange(IEnumerable<INotification> notifications);
        IReadOnlyList<INotification> GetAll();
    }
}
