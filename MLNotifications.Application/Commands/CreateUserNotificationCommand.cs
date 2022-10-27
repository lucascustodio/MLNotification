using MLNotifications.Application.Commands.Base;

namespace MLNotifications.Application.Commands
{
    public class CreateUserNotificationCommand : Command
    {
        public Guid UserId { get;  set; }
        public Guid NotificationId { get;  set; }
        public string Message { get;  set; }
    }
}
