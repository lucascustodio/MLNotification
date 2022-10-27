using MLNotifications.Domain.Aggregates.UserNotificationAggregate;

namespace MLNotifications.Application.Services.Interfaces
{
    public interface IPushNotificationService
    {
        Task<string> Send(UserNotification userNotification);

        Task SendScheduled();
    }
}
