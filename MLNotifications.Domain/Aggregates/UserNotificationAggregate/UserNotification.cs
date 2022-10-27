using MLNotifications.Domain.Base;
using MLNotifications.Domain.Aggregates.NotificationAggregate;
using MLNotifications.Domain.Enum;

namespace MLNotifications.Domain.Aggregates.UserNotificationAggregate
{
    public class UserNotification : Entity
    {
        public Guid UserId { get; private set; }
        public Notification Notification { get; private set; }
        public string Message { get; private set; }
        public DateTime SendDate { get; private set; }
        public DateTime? ReadDate { get; private set; }
        public DateTime? ScheduleDate { get; private set; }
        public NotiticationStatus Status { get; private set; }

        protected UserNotification()
        {

        }

        public UserNotification(Guid userId, string message, Notification notification)
        {
            UserId = userId;
            Message = message;
            SendDate = DateTime.UtcNow;
            ReadDate = null;
            Notification = notification;
            Status = NotiticationStatus.Created;            
        }

        public void Schedule(int days)
        {
            Status = NotiticationStatus.Scheduled;
            ScheduleDate = DateTime.UtcNow.AddDays(days);
        }

        public void SetRead()
        {
            ReadDate = DateTime.Now;
            Status = NotiticationStatus.Read;
        }
    }
}

