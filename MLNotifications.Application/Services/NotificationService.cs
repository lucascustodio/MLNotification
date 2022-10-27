using MLNotifications.Application.Commands;
using MLNotifications.Application.Services.Interfaces;
using MLNotifications.Application.Validators;
using MLNotifications.Domain.Aggregates.NotificationAggregate;
using MLNotifications.Domain.Aggregates.NotificationAggregate.Interface;
using MLNotifications.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNotifications.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INofiticationRepository _nofiticationRepository;
        private readonly ICreateNotificationCommandValidator _createNotificationCommandValidator;
        private readonly IUpdateNotificationCommandValidator _updateNotificationCommandValidator;

        public NotificationService(INofiticationRepository nofiticationRepository,
                                   ICreateNotificationCommandValidator createNotificationCommandValidator,
                                   IUpdateNotificationCommandValidator updateNotificationCommandValidator)
        {
            _nofiticationRepository = nofiticationRepository;
            _createNotificationCommandValidator = createNotificationCommandValidator;
            _updateNotificationCommandValidator = updateNotificationCommandValidator;
        }

        public async Task<CommandResponse> Add(CreateNotificationCommand command)
        {
            var validator = await _createNotificationCommandValidator.ValidateAsync(command);

            if (!validator.IsValid)
            {
                if (!validator.IsValid)
                    return CommandResponse.GenerateErrorValidatior<CreateNotificationCommand>(validator);

            }

            var notification = new Notification(command.Name,(Domain.Enum.NotiticationType)command.TypeId, (Domain.Enum.PushDevice)command.DeviceId, command.IsScheduled, command.DaysToSend);


            await _nofiticationRepository.AddAsync(notification);
            await _nofiticationRepository.SaveChanges();


            return new CommandResponse(notification.Notifications?.ToList());
        }

        public async Task<CommandResponse> Delete(Guid id)
        {
            var notification = await _nofiticationRepository.GetByIdAsync(id);
            _nofiticationRepository.Remove(notification);
            await _nofiticationRepository.SaveChanges();

            return new CommandResponse();
        }

        public async Task<Notification> GetById(Guid userId)
        {
            var notification = await _nofiticationRepository.GetByIdAsync(userId);
            return notification;
        }

        public async Task<List<Notification>> GetAll()
        {
            var notification = await _nofiticationRepository.GetAll();
            return notification;
        }


        public async Task<CommandResponse> Update(UpdateNotificationCommand command)
        {
            var notification = await _nofiticationRepository.GetByIdAsync(command.Id);

            var validator = await _updateNotificationCommandValidator.ValidateAsync(command);

            if (!validator.IsValid)
            {
                if (!validator.IsValid)
                    return CommandResponse.GenerateErrorValidatior<CreateNotificationCommand>(validator);

            }

            notification.Update(command.Name,(NotiticationType)command.TypeId, command.IsScheduled, command.DaysToSend, (PushDevice)command.DeviceId);

            _nofiticationRepository.Update(notification);
            await _nofiticationRepository.SaveChanges();

            return new CommandResponse(notification.Notifications?.ToList());
        }
    }
}
