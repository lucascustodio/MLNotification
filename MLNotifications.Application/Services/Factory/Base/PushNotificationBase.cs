using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNotifications.Application.Services.Factory.Base
{
    public abstract class PushNotificationBase
    {
        public abstract Task<string> Send();
    }
}
