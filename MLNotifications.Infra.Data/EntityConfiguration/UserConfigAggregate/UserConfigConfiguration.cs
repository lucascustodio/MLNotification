using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MLNotifications.Domain.Aggregates.UserConfigAggregate;

namespace MLNotifications.Infra.Data.EntityConfiguration.UserConfigAggregate
{
    public class UserConfigConfiguration : IEntityTypeConfiguration<UserConfig>
    {
        public void Configure(EntityTypeBuilder<UserConfig> builder)
        {
            builder.ToTable("UserConfigs");
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(14);
            builder.Property(x => x.CellPhone).IsRequired().HasMaxLength(14);
            builder.Property<bool>("IsDeleted").HasDefaultValue(false).IsRequired();
        }
    }
}
