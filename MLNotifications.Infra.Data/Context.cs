using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MLNotifications.Domain.Aggregates.UserConfigAggregate;
using MLNotifications.Domain.Aggregates.UserNotificationAggregate;

namespace MLNotifications.Infra.Data
{
    public class Context : DbContext
    {
        public static readonly string SCHEMA = "dbo";
        public static readonly string MIGRATIONS_HISTORY_TABLE = "_EFMigrationHistory";

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SCHEMA);

            modelBuilder.Ignore<Notification>();
            modelBuilder.Ignore<Enum>();

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Domain.Aggregates.NotificationAggregate.Notification> Notifications { get; set; }
        public DbSet<UserConfig> UserConfigs { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
    }

    public class ContextDesignFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer("Server=host.docker.internal,1401;Database=MLNotification;User ID=sa;Password=mudar123@mudar123;Trusted_Connection=false;");

            return new Context(optionsBuilder.Options);
        }
    }
}
