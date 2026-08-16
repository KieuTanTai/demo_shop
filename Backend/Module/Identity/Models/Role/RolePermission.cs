namespace Identity.Models.Role
{
    public class RolePermission
    {
        public Guid RoleId { get; init; }

        public Guid PermissionId { get; init; }

        public DateTime? AssignedAt { get; init; } = DateTime.UtcNow;
    }
}
