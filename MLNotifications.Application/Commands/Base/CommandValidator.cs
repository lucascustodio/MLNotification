using FluentValidation;

namespace MLNotifications.Application.Commands.Base
{
    public abstract class CommandValidator<T> : AbstractValidator<T> where T : Command
    {
        public CommandValidator()
        {
            CreateRules();
        }

        protected abstract void CreateRules();

    }
}
