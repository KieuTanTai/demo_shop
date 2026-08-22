namespace Identity.Models.Role
{
    public class RolePermissionModel
    {
        public Guid RoleId { get; init; }

        public Guid PermissionId { get; init; }

        public DateTime AssignedAt { get; init; } = DateTime.UtcNow;
    }
}