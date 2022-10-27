using MLNotifications.Infra.Data;

namespace MLNotifications.Extensions
{
    public static class IWebHostExtensions
    {
        public static IHost MigrateContext(this IHost webHost)
        {
            var configuration = webHost.Services.GetRequiredService<IConfiguration>();

            using var scope = webHost.Services.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            var logger = serviceProvider.GetRequiredService<ILogger<Context>>();
            var globalContext = serviceProvider.GetService<Context>();
            var environment = serviceProvider.GetService<IWebHostEnvironment>();

            var connectionString = configuration.GetConnectionString("DbConnection");
            logger.LogInformation(connectionString);
            try
            {
                var migrator = serviceProvider.GetService<IContextMigrator>();
               // var connectionString = configuration.GetConnectionString("DbConnection");
               
                migrator.ApplyMigration(connectionString);

                logger.LogInformation($"Base criada/atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                logger.LogInformation(connectionString);
                logger.LogError(ex, "Ocorreu um erro ao migrar o banco");
                throw;
            }

            return webHost;
        }
    }
}
