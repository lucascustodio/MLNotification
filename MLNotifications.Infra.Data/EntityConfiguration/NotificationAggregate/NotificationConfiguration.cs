using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MLNotifications.Domain.Aggregates.NotificationAggregate;

namespace MLNotifications.Infra.Data.EntityConfiguration.NotificationAggregate
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.IsScheduled).IsRequired();
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Device).IsRequired();
            builder.Property(x => x.DaysToSend).IsRequired();
            builder.Property<bool>("IsDeleted").HasDefaultValue(false).IsRequired();
        }
    }
}
