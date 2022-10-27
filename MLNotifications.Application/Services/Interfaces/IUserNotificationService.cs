using MLNotifications.Application.Commands;
using MLNotifications.Application.ViewModels;
using MLNotifications.Domain.Aggregates.UserNotificationAggregate;

namespace MLNotifications.Application.Services.Interfaces
{
    public interface IUserNotificationService
    {
        Task<IEnumerable<UserNotificationViewModel>> Get(Guid userId);
        Task<CommandResponse<UserNotification>> Add(CreateUserNotificationCommand command);
        Task<CommandResponse> Update(UpdateUserNotificationCommand command);
        Task<CommandResponse> Delete(Guid id);

    }
}
