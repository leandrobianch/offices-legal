using System.Collections.Generic;

namespace OfficesLegal.Common
{
    public interface INotificationValidation
    {
        void AddMessage(NotificationMessageValidation notificationMessageValidation);
        IEnumerable<NotificationMessageValidation> GetMessages();
        bool HasNotifications();
    }
    public class NotificationValidation : INotificationValidation
    {
        private readonly List<NotificationMessageValidation> _notications;
        public NotificationValidation()
        {
            _notications = new List<NotificationMessageValidation>(); 
        }

        public void AddMessage(NotificationMessageValidation notificationMessageValidation)
        {
            _notications.Add(notificationMessageValidation);
        }

        public IEnumerable<NotificationMessageValidation> GetMessages()
        {
            return _notications;
        }

        public bool HasNotifications()
        {
            return _notications.Count > 0;
        }
    }

    public class NotificationMessageValidation
    {
        public NotificationMessageValidation(string message)
        {
            Message = message;
        }
        public string Message { get; }
    }
}
