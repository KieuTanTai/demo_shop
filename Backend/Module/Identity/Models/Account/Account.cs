namespace Module.Identity.Models;

public class Account
{
    public Guid AccountId { get; set; }

    public string AccountEmail { get; set; } = string.Empty;

    public string AccountPassword { get; set; } = string.Empty;

    public bool AccountLoginStatus { get; set; } = false;

    public DateTime? AccountCreatedAt { get; set; } = DateTime.Now;

    public DateTime? AccountUpdatedAt { get; set; } = DateTime.Now;
}
