using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MLNotifications.Domain.Aggregates.UserNotificationAggregate;

namespace MLNotifications.Infra.Data.EntityConfiguration.UserNotificationAggregate
{
    public class UserNotificationConfiguration : IEntityTypeConfiguration<UserNotification>
    {
        public void Configure(EntityTypeBuilder<UserNotification> builder)
        {
            builder.ToTable("UserNotifications");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.UserId).IsRequired();

            builder.HasOne(x => x.Notification)
              .WithMany()
              .HasForeignKey("NotificationId");

            builder.Property(x => x.Message).IsRequired();
            builder.Property(x => x.SendDate).IsRequired();
            builder.Property(x => x.ReadDate).IsRequired(false);
            builder.Property(x => x.ScheduleDate).IsRequired(false);
            builder.Property(x => x.Status).IsRequired();

            builder.Property<bool>("IsDeleted").HasDefaultValue(false).IsRequired();
        }
    }
}
