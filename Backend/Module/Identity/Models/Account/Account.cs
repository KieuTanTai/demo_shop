using System.ComponentModel.DataAnnotations;

namespace Identity.Models.Account
{
    public class Account
    {
        public Guid AccountId { get; init; }

        [MaxLength(255)]
        public string AccountEmail { get; set; } = string.Empty;

        [MaxLength(255)]
        public string AccountPassword { get; set; } = string.Empty;

        public bool AccountIsActive { get; private set; } = true;

        public DateTime? AccountCreatedAt { get; init; } = DateTime.Now;

        public DateTime? AccountUpdatedAt { get; private set; } = DateTime.Now;
    
        public void UpdateEmail(string email)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(email);
            AccountEmail = email.Trim();
            AccountUpdatedAt = DateTime.UtcNow;
        }

        public void UpdateAccountIsActive(bool isActive)
        {
            if (AccountIsActive != isActive)
                AccountIsActive = isActive;
        }

        public void UpdateAccountPassword(string password)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(password);
            AccountPassword = password;
            AccountUpdatedAt = DateTime.UtcNow;
        }
    }
}
