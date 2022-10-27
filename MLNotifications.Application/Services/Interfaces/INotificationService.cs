using MLNotifications.Application.Commands;
using MLNotifications.Domain.Aggregates.NotificationAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNotifications.Application.Services.Interfaces
{
    public interface INotificationService
    {
        Task<List<Notification>> GetAll();
        Task<Notification> GetById(Guid id);
        Task<CommandResponse> Add(CreateNotificationCommand notification);
        Task<CommandResponse> Update(UpdateNotificationCommand notification);
        Task<CommandResponse> Delete(Guid id);

    }
}
