using MLNotifications.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNotifications.Domain.Aggregates.UserConfigAggregate.Interface
{
    public interface IUserConfigRepository : IRepository<UserConfig>
    {
    }
}
