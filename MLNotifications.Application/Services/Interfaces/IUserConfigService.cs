using MLNotifications.Domain.Aggregates.UserConfigAggregate;

namespace MLNotifications.Application.Services.Interfaces
{
    public interface IUserConfigService
    {
        Task<UserConfig> Get(Guid userId);
        Task Add(UserConfig userConfig);
        Task Update(UserConfig userConfig);
        void Delete(Guid id);
    }
}
