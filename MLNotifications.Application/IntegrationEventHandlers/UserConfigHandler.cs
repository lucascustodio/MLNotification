using MLNotifications.Application.IntegrationEventHandlers.Events;
using MLNotifications.Domain.Aggregates.UserConfigAggregate;
using MLNotifications.Domain.Aggregates.UserConfigAggregate.Interface;
using Rebus.Handlers;

namespace MLNotifications.Application.IntegrationEventHandlers
{
    public class UserConfigHandler : IHandleMessages<UserConfigCreatedIntegrationEvent>,
                                     IHandleMessages<UserConfigUpdatedIntegrationEvent>,
                                     IHandleMessages<UserConfigRemovedIntegrationEvent>
    {
        private readonly IUserConfigRepository _repository;

        public UserConfigHandler(IUserConfigRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UserConfigRemovedIntegrationEvent message)
        {
            var model = await _repository.GetByIdAsync(message.UserId);

            if (model == null)
                return;

            _repository.Remove(model);
            await _repository.SaveChanges();
        }

        public async Task Handle(UserConfigUpdatedIntegrationEvent message)
        {
            var model = await _repository.GetByIdAsync(message.UserId);
            if (model != null)
            {
                model.Update(message.FullName, message.Phone, message.CellPhone);
                _repository.Update(model);
            }
            else
            {
                var userConfig = new UserConfig(message.UserId, message.FullName, message.Email, message.Phone, message.CellPhone);
                await _repository.AddAsync(userConfig);
            }
            await _repository.SaveChanges();
        }

        public async Task Handle(UserConfigCreatedIntegrationEvent message)
        {
            var userConfig = new UserConfig(message.UserId, message.FullName, message.Email, message.Phone, message.CellPhone);
            await _repository.AddAsync(userConfig);

            await _repository.SaveChanges();
        }
    }
}
