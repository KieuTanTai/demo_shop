public class Account
{
    public Guid AccountId { get; set; }

    public string AccountEmail { get; set; } = string.Empty;

    public string AccountPassword { get; set; } = string.Empty;

    public bool AccountLoginStatus { get; set; } = true;

    public DateTime? AccountCreatedAt { get; set; }

    public DateTime? AccountUpdatedAt { get; set; }
}
