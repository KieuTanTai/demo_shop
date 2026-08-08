public class Permission
{
    public Guid PermissionId { get; set; }

    public string PermissionName { get; set; } = string.Empty;

    public string? PermissionDescription { get; set; }

    public DateTime? PermissionCreatedAt { get; set; }
}
