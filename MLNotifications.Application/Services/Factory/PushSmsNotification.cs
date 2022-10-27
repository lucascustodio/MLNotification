using MLNotifications.Application.Services.Factory.Base;
using MLNotifications.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNotifications.Application.Services.Factory
{
    public class PushSmsNotification : PushNotificationBase
    {
        public override Task<string> Send()
        {
            return Task.FromResult("Message has been sent");
        }
    }
}
