namespace MLNotifications.Application.IntegrationEventHandlers.Events
{
    public class UserConfigCreatedIntegrationEvent
    {
        public Guid UserId { get;  set; }
        public string FullName { get;  set; }
        public string Email { get;  set; }
        public string Phone { get;  set; }
        public string CellPhone { get;  set; }
    }
}
