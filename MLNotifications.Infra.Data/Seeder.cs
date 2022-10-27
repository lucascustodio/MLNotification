using MLNotifications.Domain.Aggregates.NotificationAggregate;
using MLNotifications.Domain.Aggregates.UserConfigAggregate;
using MLNotifications.Domain.Enum;
using MLNotifications.Infra.Data;

namespace MLNotifications.Infra.Data
{
    public class Seeder
    {
        Context _context;

        public Seeder(Context context)
        {
            _context = context;
        }

        public void Seed()
        {
            SeedNotifications();
            SeedUserConfig();
        }


        private void SeedNotifications()
        {
            var notifications = new List<Notification>()
            {
                new Notification("Novo Pedido - Sem agendamento",NotiticationType.NewOrder, PushDevice.Web, false, 0),
                new Notification("Novo Pedido - Com agendamento",NotiticationType.NewOrder, PushDevice.Web, true, 360),
                new Notification("Alteração Status do Pedido",NotiticationType.StatusChange, PushDevice.Web, false, 0),
            };

            var hasNotifications = _context.Notifications.Any();

            if (!hasNotifications)
                _context.Notifications.AddRange(notifications);
        }

        private void SeedUserConfig()
        {
            var userConfigs = new List<UserConfig>()
            {
                new UserConfig(Guid.NewGuid(),"Usuário 01", "usuario1.gmail.com","6548616815","325566585"),
                new UserConfig(Guid.NewGuid(),"Usuário 02", "usuario2.gmail.com","3541815252","325566588"),
                new UserConfig(Guid.NewGuid(),"Usuário 03", "usuario3.gmail.com","5465165155","325566678"),
                new UserConfig(Guid.NewGuid(),"Usuário 04", "usuario4.gmail.com","8668546566","234234256"),
                new UserConfig(Guid.NewGuid(),"Usuário 05", "usuario5.gmail.com","4848853354","425345454")

            };

            var hasUserConfigs = _context.Notifications.Any();

            if (!hasUserConfigs)
                _context.UserConfigs.AddRange(userConfigs);
        }
    }
}
