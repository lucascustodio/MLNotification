using MLNotifications.Domain.Enum;

namespace MLNotifications.Application.ViewModels
{
    public class UserNotificationViewModel
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public NotiticationStatus Status { get; set; }
    }
}
