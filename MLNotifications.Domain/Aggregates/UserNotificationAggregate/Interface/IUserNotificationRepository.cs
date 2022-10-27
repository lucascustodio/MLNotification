using MLNotifications.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNotifications.Domain.Aggregates.UserNotificationAggregate.Interface
{
    public interface IUserNotificationRepository : IRepository<UserNotification>
    {
        Task<IEnumerable<UserNotification>> Get(Guid userId);
        Task<IEnumerable<UserNotification>> GetByDate(DateTime date);
    }
}
