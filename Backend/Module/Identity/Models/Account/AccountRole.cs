namespace Identity.Models.Account
{
    public class AccountRole
    {
        public Guid AccountId { get; init; }

        public Guid RoleId { get; init; }

        public DateTime? AssignedAt { get; init; } = DateTime.UtcNow;
    }
}
