namespace Identity.Models.Role
{
    public class RolePermissionModel(Guid roleId, Guid permissionId)
    {
        public Guid RoleId { get; init; } = roleId;

        public Guid PermissionId { get; init; } = permissionId;

        public DateTime AssignedAt { get; init; } = DateTime.UtcNow;
    }
}