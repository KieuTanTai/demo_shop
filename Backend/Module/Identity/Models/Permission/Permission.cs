using System.ComponentModel.DataAnnotations;

namespace Identity.Models.Permission
{
    public class Permission
    {
        public Guid PermissionId { get; init; }

        [MaxLength(150)]
        public string PermissionName { get; set; } = string.Empty;

        [MaxLength(300)]
        public string? PermissionDescription { get; set; } = string.Empty;

        public bool PermissionActive { get; init; } = true;


        public DateTime? PermissionCreatedAt { get; init; } = DateTime.Now;

        public DateTime? PermissionUpdatedAt { get; init; } = DateTime.Now;
    }
}
