using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNotifications.Application.IntegrationEventHandlers.Events
{
    public class UserConfigRemovedIntegrationEvent
    {
        public Guid UserId { get; set; }
    }
}
