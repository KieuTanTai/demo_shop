namespace Identity.Models.Account
{
    public class AccountRoleModel
    {
        public Guid AccountId { get; init; }

        public Guid RoleId { get; init; }

        public DateTime AssignedAt { get; init; } = DateTime.UtcNow;
    }
}