public class Permission
{
    public Guid PermissionId { get; set; }

    public string PermissionName { get; set; } = string.Empty;

    public string? PermissionDescription { get; set; } = string.Empty;

    public bool PermissionActive { get; set; } = true;


    public DateTime? PermissionCreatedAt { get; set; } = DateTime.Now;

    public DateTime? PermissionUpdatedAt { get; set; } = DateTime.Now;
}
