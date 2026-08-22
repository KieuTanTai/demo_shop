using System.ComponentModel.DataAnnotations;
using Shared.ModelHelper;
namespace Identity.Models.Role
{
    public class Role
    {
        public Guid RoleId { get; init; }

        [MaxLength(150)]
        public string RoleName { get; private set; } = string.Empty;

        [MaxLength(300)]
        public string? RoleDescription { get; private set; }

        public bool RoleIsActive { get; private set; } = true;

        public DateTime RoleCreatedAt { get; init; } = DateTime.UtcNow;

        public DateTime RoleUpdatedAt { get; private set; } = DateTime.UtcNow;

        public IReadOnlyList<Permission.Permission> Permissions { get; private set; } = new List<Permission.Permission>();
        
        #region Setter

        public void SetRoleName(string name)
        {
            RoleName = ModelFieldGuard.Required(name, 100, nameof(name));
            RoleUpdatedAt = DateTime.UtcNow;
        }
        
        public void SetRoleIsActive(bool isActive)
        {
            if (RoleIsActive == isActive)
                return;

            RoleIsActive = isActive;
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

        public void SetPermissions(IReadOnlyList<Permission.Permission> permissions)
        {
            Permissions = permissions;
        }
        
        #endregion
    }
}
