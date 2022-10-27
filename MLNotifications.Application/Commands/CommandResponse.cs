using Flunt.Notifications;
using MLNotifications.Application.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNotifications.Application.Commands
{
    
    public class CommandResponse
    {
        public List<Notification> Notifications { get; protected set; } = new List<Flunt.Notifications.Notification>();

        public bool Valid => (Notifications == null || Notifications.Count == 0);
        public bool Invalid => (Notifications != null && Notifications.Count != 0);

        public CommandResponse()
        {

        }

        public CommandResponse(List<Flunt.Notifications.Notification> notifications)
        {
            Notifications = notifications;
        }

        public CommandResponse(Flunt.Notifications.Notification notification)
        {

            Notifications.Add(notification);
        }

        public static CommandResponse GenerateErrorValidatior<T>(FluentValidation.Results.ValidationResult validator) where T : Command
        {
            return new CommandResponse(validator.Errors.Select(x => new Flunt.Notifications.Notification(nameof(T), x.ErrorMessage)).ToList());
        }
    }

    public class CommandResponse<TData> : CommandResponse
    {
        public TData Data { get; }

        public CommandResponse(TData data, List<Flunt.Notifications.Notification> notifications, string message) : base(notifications)
        {
            Data = data;
        }

        public CommandResponse(TData data, List<Flunt.Notifications.Notification> notifications) : this(data, notifications, null) { }
    }
}

