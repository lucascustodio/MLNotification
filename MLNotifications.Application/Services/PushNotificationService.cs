using MLNotifications.Application.Services.Factory;
using MLNotifications.Application.Services.Interfaces;
using MLNotifications.Domain.Aggregates.UserNotificationAggregate;
using MLNotifications.Domain.Aggregates.UserNotificationAggregate.Interface;

namespace MLNotifications.Application.Services
{
    public class PushNotificationService : IPushNotificationService
    {

        private readonly IUserNotificationRepository _userNotificationRepository;
        public PushNotificationService(IUserNotificationRepository userNotificationRepository)
        {
            _userNotificationRepository = userNotificationRepository;
        }

        public async Task<string> Send(UserNotification userNotification)
        {
            if (!userNotification.Notification.IsScheduled)
            {
                var push = new PushNotificationFactory();
                return await push.Send(userNotification);
            }
            else
                return null;
        }


        public async Task SendScheduled()
        {

            var notifications = await _userNotificationRepository.GetByDate(DateTime.Now);

            foreach (var notification in notifications)
            {
                await Send(notification);
            }
        }
    }
}
