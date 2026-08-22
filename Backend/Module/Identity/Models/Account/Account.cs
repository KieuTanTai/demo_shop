using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Shared.ModelHelper;

namespace Identity.Models.Account
{
    public class Account
    {
        public Guid AccountId { get; init; }

        [MaxLength(255)]
        public string AccountEmail { get; private set; } = string.Empty;

        [MaxLength(255)]
        public string AccountPassword { get; private set; } = string.Empty;

        [MaxLength(10)]
        public string? AccountPhone { get; private set; }

        public bool AccountIsActive { get; private set; } = true;
        
        public DateTime AccountCreatedAt { get; init; } = DateTime.UtcNow;

        public DateTime AccountUpdatedAt { get; private set; } = DateTime.UtcNow;

        public IReadOnlyList<Role.Role> Roles { get; private set; } = new List<Role.Role>();
        
        public IReadOnlyList<Permission.Permission> Permissions { get; private set; } = new List<Permission.Permission>();
        
        #region Setter
        
        public void SetEmail(string email)
        {
            AccountEmail = ModelFieldGuard.Required(email, 255, nameof(email));
            AccountUpdatedAt = DateTime.UtcNow;
        }

        public void SetAccountIsActive(bool isActive)
        {
            if (AccountIsActive == isActive)
                return;
            AccountIsActive = isActive;
            AccountUpdatedAt = DateTime.UtcNow;
        }

        public void SetPasswordHash(string passwordHash)
        {
            AccountPassword = ModelFieldGuard.Required(passwordHash, 255, nameof(passwordHash));
            AccountUpdatedAt = DateTime.UtcNow;
        }

        public void ClearAccountPhone()
        {
            if (AccountPhone is null)
                return;
            AccountPhone = null;
            AccountUpdatedAt = DateTime.UtcNow;
        }
        
        public void SetAccountPhone(string phone)
        {
            var baseValidPhone = ModelFieldGuard.Required(phone, 10, nameof(phone));
            const string pattern = @"^(03|05|07|08|09)\d{8}$";
            if (!Regex.IsMatch(baseValidPhone, pattern))
                throw new ArgumentException("Phone number must be a valid Vietnamese 10-digit phone number.", nameof(phone));
            AccountPhone = baseValidPhone;
            AccountUpdatedAt = DateTime.UtcNow;
        }

        public void SetRoles(IReadOnlyList<Role.Role> roles)
        {
            Roles = roles;
        }
        
        public void SetPermissions(IReadOnlyList<Permission.Permission> permissions)
        {
            Permissions = permissions;
        }       
        
        #endregion
    }
}
