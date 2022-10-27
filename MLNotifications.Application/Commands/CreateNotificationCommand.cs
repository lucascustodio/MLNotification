using MLNotifications.Application.Commands.Base;

namespace MLNotifications.Application.Commands
{
    public class CreateNotificationCommand : Command
    {
        public string Name{ get; set; }
        public int TypeId { get; set; }
        public int DeviceId { get; set; }
        public bool IsScheduled { get; set; }
        public int DaysToSend { get; set; }
    }
}
