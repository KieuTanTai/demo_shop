using System.ComponentModel.DataAnnotations;
using Shared.ModelHelper;

namespace Identity.Models.Permission
{
    public class PermissionModel(Guid permissionId, string? permissionDescription, bool permissionIsActive)
    {
        public Guid PermissionId { get; init; } = permissionId;

        [MaxLength(50)] public string PermissionCode { get; private set; } = string.Empty;

        [MaxLength(150)] public string PermissionName { get; private set; } = string.Empty;

        [MaxLength(300)] public string? PermissionDescription { get; private set; } = permissionDescription;

        public bool PermissionIsActive { get; private set; } = permissionIsActive;


        public DateTime PermissionCreatedAt { get; init; } = DateTime.UtcNow;

        public DateTime PermissionUpdatedAt { get; private set; } = DateTime.UtcNow;


        #region Setter

        public void SetPermissionName(string name)
        {
            PermissionName = ModelFieldGuard.Required(name, 150, nameof(name));
            PermissionUpdatedAt = DateTime.UtcNow;
        }

        public void SetPermissionIsActive(bool isActive)
        {
            if (PermissionIsActive == isActive)
            {
                return;
            }

            PermissionIsActive = isActive;
            PermissionUpdatedAt = DateTime.UtcNow;
        }

        public void ClearPermissionDescription()
        {
            if (PermissionDescription is null)
            {
                return;
            }

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