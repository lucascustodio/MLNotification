namespace MLNotifications.Domain.Aggregates.UserConfigAggregate
{
    public class UserConfig
    {
        public UserConfig(Guid userId, string fullName, string email, string phone, string cellPhone)
        {
            UserId = userId;
            FullName = fullName;
            Email = email;
            Phone = phone;
            CellPhone = cellPhone;
        }

        public Guid UserId { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string CellPhone { get; private set; }

        public void Update(string fullName, string phone, string cellPhone)
        {
            FullName = fullName;
            Phone = phone;
            CellPhone = cellPhone;
        }
    }
}
