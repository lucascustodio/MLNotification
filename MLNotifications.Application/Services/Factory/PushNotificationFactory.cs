using MLNotifications.Domain.Aggregates.UserNotificationAggregate;
using MLNotifications.Domain.Enum;

namespace MLNotifications.Application.Services.Factory
{
    public class PushNotificationFactory
    {

        public PushNotificationFactory()
        {
        }

        public async Task<string> Send(UserNotification userNotification)
        {
            var response = string.Empty;

            switch (userNotification.Notification.Device)
            {
                case PushDevice.Email:
                    var pushEmail = new PushEmailNotification();
                    response = await pushEmail.Send();
                    break;
                case PushDevice.Web:
                    var pushWebApplication = new PushWebApplicationNotification();
                    response = await pushWebApplication.Send();
                    break;
                case PushDevice.Sms:
                    var pushSms = new PushSmsNotification();
                    response = await pushSms.Send();
                    break;
                default:                    
                    break;
            }

            return response;
        }
    }
}
