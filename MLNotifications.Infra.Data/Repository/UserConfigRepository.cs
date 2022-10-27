using MLNotifications.Domain.Aggregates.UserConfigAggregate;
using MLNotifications.Domain.Aggregates.UserConfigAggregate.Interface;
using MLNotifications.Infra.Data.Repository.Base;

namespace MLNotifications.Infra.Data.Repository
{
    public class UserConfigRepository : Repository<UserConfig>, IUserConfigRepository
    {
        public UserConfigRepository(Context context) : base(context)
        {
        }
    }
}
