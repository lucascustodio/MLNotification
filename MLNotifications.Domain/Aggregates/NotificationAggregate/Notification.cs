using MLNotifications.Domain.Base;
using MLNotifications.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNotifications.Domain.Aggregates.NotificationAggregate
{
    public class Notification : Entity
    {
        protected Notification()
        {

        }

        public Notification(string name, NotiticationType type, PushDevice device, bool isScheduled, int hoursToSend)
        {
            Name = name;
            Type = type;
            Device = device;
            IsScheduled = isScheduled;
            DaysToSend = hoursToSend;
        }

        public string Name { get; set; }
        public NotiticationType Type { get; set; }
        public PushDevice Device { get; set; }
        public bool IsScheduled { get; set; }
        public int DaysToSend { get; set; }

        public void Update(string name, NotiticationType type, bool isScheduled, int hoursToSend, PushDevice pushDevice)
        {
            Name = name;
            Type = type;
            Device = pushDevice;
            IsScheduled = isScheduled;
            DaysToSend = hoursToSend;
        }
    }
}
