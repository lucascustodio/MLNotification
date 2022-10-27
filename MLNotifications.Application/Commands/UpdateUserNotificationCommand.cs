using MLNotifications.Application.Commands.Base;

namespace MLNotifications.Application.Commands
{
    public class UpdateUserNotificationCommand : Command
    {
        public Guid Id { get;  set; }
    }
}
