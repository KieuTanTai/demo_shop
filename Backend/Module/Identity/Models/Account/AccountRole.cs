namespace Module.Identity.Models;

public class AccountRole
{
    public Guid AccountId { get; set; }

    public Guid RoleId { get; set; }

    public DateTime? AssignedAt { get; set; } = DateTime.Now;
}
