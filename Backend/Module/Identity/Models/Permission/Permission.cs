using System.ComponentModel.DataAnnotations;
using Shared.ModelHelper;

namespace Identity.Models.Permission
{
    public class Permission
    {
        public Guid PermissionId { get; init; }

        [MaxLength(150)]
        public string PermissionName { get; private set; } = string.Empty;

        [MaxLength(300)]
        public string? PermissionDescription { get; private set; } = string.Empty;

        public bool PermissionActive { get; private set; } = true;


        public DateTime? PermissionCreatedAt { get; init; } = DateTime.UtcNow;

        public DateTime? PermissionUpdatedAt { get; private set; } = DateTime.UtcNow;

        
        #region Setter

        public void SetPermissionName(string name)
        {
            PermissionName = ModelFieldGuard.Required(name, 150, nameof(name));
            PermissionUpdatedAt = DateTime.UtcNow;
        }

        public void SetPermissionActive(bool isActive)
        {
            if (PermissionActive == isActive)
                return;

            PermissionActive = isActive;
            PermissionUpdatedAt = DateTime.UtcNow;
        }

        public void ClearPermissionDescription()
        {
            if (PermissionDescription is null)
                return;

            PermissionDescription = null;
            PermissionUpdatedAt = DateTime.UtcNow;
        }
        
        public void SetPermissionDescription(string description)
        {
            PermissionDescription = ModelFieldGuard.Required(description, 300, nameof(description));
            PermissionUpdatedAt = DateTime.UtcNow;
        }
        
        #endregion
    }
}
