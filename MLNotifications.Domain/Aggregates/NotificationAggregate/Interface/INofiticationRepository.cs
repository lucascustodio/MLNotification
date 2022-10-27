using MLNotifications.Domain.Interface;

namespace MLNotifications.Domain.Aggregates.NotificationAggregate.Interface
{
    public interface INofiticationRepository : IRepository<Domain.Aggregates.NotificationAggregate.Notification>
    {
    }
}
