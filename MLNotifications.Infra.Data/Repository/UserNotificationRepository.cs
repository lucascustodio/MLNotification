using Microsoft.EntityFrameworkCore;
using MLNotifications.Domain.Aggregates.UserNotificationAggregate;
using MLNotifications.Domain.Aggregates.UserNotificationAggregate.Interface;
using MLNotifications.Infra.Data.Repository.Base;

namespace MLNotifications.Infra.Data.Repository
{
    public class UserNotificationRepository : Repository<UserNotification>, IUserNotificationRepository
    {
        public UserNotificationRepository(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<UserNotification>> Get(Guid userId)
        {
            return await _set.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<UserNotification>> GetByDate(DateTime date)
        {
            return await _set.Where(x => x.ScheduleDate.GetValueOrDefault().ToString("dd/MM/yyyy") == date.ToString("dd/MM/yyyy")).ToListAsync();
        }
    }
}
