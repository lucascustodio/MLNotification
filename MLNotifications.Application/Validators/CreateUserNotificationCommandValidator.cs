using FluentValidation;
using MLNotifications.Application.Commands;
using MLNotifications.Application.Commands.Base;

namespace MLNotifications.Application.Validators
{
    public interface ICreateUserNotificationCommandValidator : IValidator<CreateUserNotificationCommand> { }

    public class CreateUserNotificationCommandValidator : CommandValidator<CreateUserNotificationCommand>, ICreateUserNotificationCommandValidator
    {
        public CreateUserNotificationCommandValidator()
        {

        }

        protected override void CreateRules()
        {
            RuleFor(x => x.UserId)
             .NotEmpty()
             .WithMessage("User is required");

            RuleFor(x => x.NotificationId)
               .NotEmpty()
              .WithMessage("NotificationId is required");
        }
    }
}
