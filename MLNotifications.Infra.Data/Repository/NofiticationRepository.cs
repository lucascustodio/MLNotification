using MLNotifications.Domain.Aggregates.NotificationAggregate;
using MLNotifications.Domain.Aggregates.NotificationAggregate.Interface;
using MLNotifications.Infra.Data.Repository.Base;

namespace MLNotifications.Infra.Data.Repository
{
    public class NofiticationRepository : Repository<Notification>, INofiticationRepository
    {
        public NofiticationRepository(Context context) : base(context)
        {
        }
    }
}
