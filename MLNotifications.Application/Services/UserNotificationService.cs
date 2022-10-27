using MLNotifications.Application.Commands;
using MLNotifications.Application.Validators;
using MLNotifications.Application.ViewModels;
using MLNotifications.Application.Services.Interfaces;
using MLNotifications.Domain.Aggregates.UserNotificationAggregate;
using MLNotifications.Domain.Aggregates.UserNotificationAggregate.Interface;

namespace MLNotifications.Application.Services
{
    public class UserNotificationService : IUserNotificationService
    {

        private readonly ICreateUserNotificationCommandValidator _commandValidator;
        private readonly IUserNotificationRepository _userNotificationRepository;
        private readonly INotificationService _notificationService;
        private readonly IPushNotificationService _pushNotificationService;

        public UserNotificationService(IUserNotificationRepository userNotificationRepository,
                                       IPushNotificationService pushNotificationService,
                                       ICreateUserNotificationCommandValidator commandValidator,
                                       INotificationService notificationService)
        {
            _userNotificationRepository = userNotificationRepository;
            _pushNotificationService = pushNotificationService;
            _commandValidator = commandValidator;
            _notificationService = notificationService;
        }

        public async Task<CommandResponse<UserNotification>> Add(CreateUserNotificationCommand command)
        {
            var validator = await _commandValidator.ValidateAsync(command);

            if (!validator.IsValid)
                return new CommandResponse<UserNotification>(null, validator.Errors.Select(x => new Flunt.Notifications.Notification(nameof(UserNotification), x.ErrorMessage)).ToList());

            var notification = await _notificationService.GetById(command.NotificationId);

            if (notification is null)
            {
                var notifications = new List<Flunt.Notifications.Notification> { new Flunt.Notifications.Notification("notification", "Notification not found") };
                return new CommandResponse<UserNotification>(null, notifications);
            }

            var userNotification = new UserNotification(command.UserId, command.Message, notification);

            if (notification.IsScheduled)
                userNotification.Schedule(notification.DaysToSend);

            await _userNotificationRepository.AddAsync(userNotification);

            await _userNotificationRepository.SaveChanges();

            return new CommandResponse<UserNotification>(userNotification, userNotification.Notifications.ToList());
        }

        public async Task<CommandResponse> Delete(Guid id)
        {
            var userNotification = await _userNotificationRepository.GetByIdAsync(id);
            try
            {
                 _userNotificationRepository.Remove(userNotification);
                return new CommandResponse(new Flunt.Notifications.Notification("notification", null));
            }
            catch (Exception)
            {
                return new CommandResponse(new Flunt.Notifications.Notification("notification", "Notification was not deleted"));
            }
        }

        public async Task<IEnumerable<UserNotificationViewModel>> Get(Guid userId)
        {
            var userNotifications = await _userNotificationRepository.Get(userId);

            return userNotifications.Select(x => new UserNotificationViewModel() { Id = x.Id, Status = x.Status, Message = x.Message });
        }

        public async Task<CommandResponse> Update(UpdateUserNotificationCommand command)
        {
            var userNotification = await _userNotificationRepository.GetByIdAsync(command.Id);
            userNotification.SetRead();

            await _userNotificationRepository.SaveChanges();

            return new CommandResponse(userNotification.Notifications.ToList());
        }
    }
}
