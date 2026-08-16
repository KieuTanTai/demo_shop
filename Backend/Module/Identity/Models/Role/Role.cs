namespace Module.Identity.Models;

public class Role
{
    public Guid RoleId { get; set; }

    public string RoleName { get; set; } = string.Empty;

    public string? RoleDescription { get; set; } = string.Empty;

    public bool RoleActive { get; set; } = true;

    public DateTime? RoleCreatedAt { get; set; } = DateTime.Now;

    public DateTime? RoleUpdatedAt { get; set; } = DateTime.Now;
}
