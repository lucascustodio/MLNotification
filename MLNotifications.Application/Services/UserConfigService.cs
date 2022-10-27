using MLNotifications.Application.Services.Interfaces;
using MLNotifications.Domain.Aggregates.UserConfigAggregate;
using MLNotifications.Domain.Aggregates.UserConfigAggregate.Interface;

namespace MLNotifications.Application.Services
{
    public class UserConfigService : IUserConfigService
    {
        private readonly IUserConfigRepository _userConfigRepository;

        public UserConfigService(IUserConfigRepository userConfigRepository)
        {
            _userConfigRepository = userConfigRepository;
        }

        public async Task Add(UserConfig userConfig)
        {
            await _userConfigRepository.AddAsync(userConfig);
            await _userConfigRepository.SaveChanges();
        }

        public async void Delete(Guid id)
        {
            var userConfig = await _userConfigRepository.GetByIdAsync(id);
            _userConfigRepository.Remove(userConfig);
            await _userConfigRepository.SaveChanges();
        }

        public async Task<UserConfig> Get(Guid userId)
        {
            var userConfig = await _userConfigRepository.GetByIdAsync(userId);
            return userConfig;
        }

        public async Task Update(UserConfig userConfig)
        {
            var model = await _userConfigRepository.GetByIdAsync(userConfig.UserId);

            model.Update(userConfig.FullName, userConfig.Phone, userConfig.CellPhone);

            _userConfigRepository.Update(model);
            await _userConfigRepository.SaveChanges();
        }
    }
}
