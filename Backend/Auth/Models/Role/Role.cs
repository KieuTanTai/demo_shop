public class Role
{
    public Guid RoleId { get; set; }

    public string RoleName { get; set; } = string.Empty;

    public string? RoleDescription { get; set; }

    public bool RoleActive { get; set; } = true;

    public DateTime? RoleCreatedAt { get; set; }

    public DateTime? RoleUpdatedAt { get; set; }
}
