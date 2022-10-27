
using Flunt.Notifications;

namespace MLNotifications.Domain.Base
{
    public abstract class Entity : Notifiable
    {
        public virtual Guid Id { get; protected set; }
        public Entity()
        {
        }

        public Entity(Guid id)
        {
            Id = id;
        }
    }
}
