using FluentValidation;
using MLNotifications.Application.Commands;
using MLNotifications.Application.Commands.Base;

namespace MLNotifications.Application.Validators
{
    public interface IUpdateNotificationCommandValidator : IValidator<UpdateNotificationCommand> { }

    public class UpdateNotificationCommandValidator : CommandValidator<UpdateNotificationCommand>, IUpdateNotificationCommandValidator
    {
        public UpdateNotificationCommandValidator()
        {

        }

        protected override void CreateRules()
        {
            RuleFor(x => x.Id)
             .NotEmpty()
             .WithMessage("Id is required");

            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");

            RuleFor(x => x.DeviceId)
             .NotEmpty()
             .WithMessage("Device is required");

            RuleFor(x => x.TypeId)
               .NotEmpty()
              .WithMessage("TypeId is required");

            RuleFor(x => x.IsScheduled)
             .NotNull()
             .WithMessage("IsScheduled is required");

            RuleFor(x => x.DaysToSend)
             .NotNull()
             .WithMessage("DaysToSend is required");
        }
    }
}
