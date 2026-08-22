namespace Identity.Models.Account
{
    public class AccountPermissionModel
    {
        public Guid AccountId { get; init; }

        public Guid PermissionId { get; init; }

        public DateTime AssignedAt { get; init; } = DateTime.UtcNow;
    }
}