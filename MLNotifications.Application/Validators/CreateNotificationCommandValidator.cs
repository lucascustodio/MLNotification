using FluentValidation;
using MLNotifications.Application.Commands;
using MLNotifications.Application.Commands.Base;

namespace MLNotifications.Application.Validators
{
    public interface ICreateNotificationCommandValidator : IValidator<CreateNotificationCommand> { }

    public class CreateNotificationCommandValidator : CommandValidator<CreateNotificationCommand>, ICreateNotificationCommandValidator
    {
        public CreateNotificationCommandValidator()
        {

        }

        protected override void CreateRules()
        {
            RuleFor(x => x.Name)
              .NotEmpty()
              .WithMessage("Name is required");

            RuleFor(x => x.DeviceId)
             .NotEmpty()
             .WithMessage("Device is required");

            RuleFor(x => x.TypeId)
               .NotEmpty()
              .WithMessage("TypeId is required");

         
        }
    }
}
