using Cel.Estudos.CoreDomain.Notification;

namespace Cel.Estudos.CoreDomain.Specification
{
    internal class Specificator<T> : ISpecificator<T>
    {
        private readonly INotificationContext _notificationContext;

        public Specificator(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public bool Passed => !_notificationContext.HasNotifications;

        public void Specify(T toSpecify, List<SpecificationBase<T>> specifications)
        {
            if (toSpecify == null)
            {
                _notificationContext.Add(new GenericNotification("Specification can not be null."));
                return;
            }

            specifications.ForEach(specification =>
            {
                var validation = specification.Condition();
                if (!validation(toSpecify))
                    _notificationContext.Add(new GenericNotification(specification.Message));
            });
        }
    }
}
