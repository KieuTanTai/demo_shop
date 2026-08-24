using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Identity.Models.Permission;
using Identity.Models.Role;
using Shared.ModelHelper;

namespace Identity.Models.Account
{
    public class AccountModel
    {
        public Guid AccountId { get; init; }

        [MaxLength(255)] public string AccountEmail { get; private set; } = string.Empty;

        [MaxLength(255)] public string AccountPassword { get; private set; } = string.Empty;

        [MaxLength(10)] public string? AccountPhoneNumber { get; private set; }

        public bool AccountIsActive { get; private set; } = true;

        public DateTime AccountCreatedAt { get; init; } = DateTime.UtcNow;

        public DateTime AccountUpdatedAt { get; private set; } = DateTime.UtcNow;

        public IReadOnlyList<RoleModel> Roles { get; private set; } = new List<RoleModel>();

        public IReadOnlyList<PermissionModel> Permissions { get; private set; } =
            new List<PermissionModel>();

        public AccountModel(string email, string password)
        {
            AccountEmail = ModelFieldGuard.Required(email, 255, nameof(email));
            AccountPassword = ModelFieldGuard.Required(password, 255, nameof(password));
        }
        

        #region Setter

        public void SetEmail(string email)
        {
            AccountEmail = ModelFieldGuard.Required(email, 255, nameof(email));
            AccountUpdatedAt = DateTime.UtcNow;
        }

        public void SetAccountIsActive(bool isActive)
        {
            if (AccountIsActive == isActive)
            {
                return;
            }

            AccountIsActive = isActive;
            AccountUpdatedAt = DateTime.UtcNow;
        }

        public void SetPasswordHash(string passwordHash)
        {
            AccountPassword = ModelFieldGuard.Required(passwordHash, 255, nameof(passwordHash));
            AccountUpdatedAt = DateTime.UtcNow;
        }

        public void ClearAccountPhoneNumber()
        {
            if (AccountPhoneNumber is null)
            {
                return;
            }

            AccountPhoneNumber = null;
            AccountUpdatedAt = DateTime.UtcNow;
        }

        public void SetAccountPhoneNumber(string phone)
        {
            var baseValidPhone = ModelFieldGuard.Required(phone, 10, nameof(phone));
            const string pattern = @"^(03|05|07|08|09)\d{8}$";
            if (!Regex.IsMatch(baseValidPhone, pattern))
            {
                throw new ArgumentException("Phone number must be a valid Vietnamese 10-digit phone number.",
                    nameof(phone));
            }

            AccountPhoneNumber = baseValidPhone;
            AccountUpdatedAt = DateTime.UtcNow;
        }

        public void SetRoles(IReadOnlyList<RoleModel> roles)
        {
            Roles = roles;
        }

        public void SetPermissions(IReadOnlyList<PermissionModel> permissions)
        {
            Permissions = permissions;
        }

        #endregion
    }
}