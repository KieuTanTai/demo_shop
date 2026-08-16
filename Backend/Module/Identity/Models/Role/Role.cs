using System.ComponentModel.DataAnnotations;
using Shared.ModelHelper;

namespace Identity.Models.Role
{
    public class Role
    {
        public Guid RoleId { get; init; }

        [MaxLength(100)]
        public string RoleName { get; private set; } = string.Empty;

        [MaxLength(300)]
        public string? RoleDescription { get; private set; } = string.Empty;

        public bool RoleActive { get; private set; } = true;

        public DateTime? RoleCreatedAt { get; init; } = DateTime.UtcNow;

        public DateTime? RoleUpdatedAt { get; private set; } = DateTime.UtcNow;


        #region Setter

        public void SetRoleName(string name)
        {
            RoleName = ModelFieldGuard.Required(name, 100, nameof(name));
            RoleUpdatedAt = DateTime.UtcNow;
        }
        
        public void SetRoleActive(bool isActive)
        {
            if (RoleActive == isActive)
                return;

            RoleActive = isActive;
            RoleUpdatedAt = DateTime.UtcNow;
        }

        public void ClearRoleDescription()
        {
            if (RoleDescription is null)
                return;

            RoleDescription = null;
            RoleUpdatedAt = DateTime.UtcNow;
        }
        
        public void SetRoleDescription(string description)
        {
            RoleDescription = ModelFieldGuard.Required(description, 300, nameof(description));
            RoleUpdatedAt = DateTime.UtcNow;
        }

        #endregion
    }
}
