namespace Module.Identity.Models;

public class RolePermission
{
    public Guid RoleId { get; set; }

    public Guid PermissionId { get; set; }

    public DateTime? AssignedAt { get; set; } = DateTime.Now;
}
