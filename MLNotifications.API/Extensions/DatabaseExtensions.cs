using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MLNotifications.Infra.Data;
using System.Data;
using System.Data.Common;

namespace MLNotifications.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, ConfigurationManager config)
        {
            services.AddDbContext<Context>((serviceProvider, options) =>
            {
                var connection = serviceProvider.GetRequiredService<IDbConnection>() as DbConnection;

                options.UseSqlServer(connection, sqlOpt =>
                {
                    sqlOpt.MigrationsAssembly(typeof(Context).GetType().Assembly.GetName().Name);

                    sqlOpt.MigrationsHistoryTable(Context.MIGRATIONS_HISTORY_TABLE, Context.SCHEMA);

                    sqlOpt.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null);
                });

            }, ServiceLifetime.Scoped);

            services.AddScoped<IDbConnection, DbConnection>(provider =>
            {
                string connectionString = config.GetConnectionString("DbConnection");

                return new SqlConnection(connectionString);
            });

            return services;
        }

        public static IServiceCollection AddMigrator(this IServiceCollection services)
        {
            services.AddScoped<IContextMigrator, ContextMigrator>();

            return services;
        }
    }
}
