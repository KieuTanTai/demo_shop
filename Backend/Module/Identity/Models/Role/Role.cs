using System.ComponentModel.DataAnnotations;

namespace Identity.Models.Role
{
    public class Role
    {
        public Guid RoleId { get; init; }

        [MaxLength(100)]
        public string RoleName { get; set; } = string.Empty;

        [MaxLength(300)]
        public string? RoleDescription { get; set; } = string.Empty;

        public bool RoleActive { get; init; } = true;

        public DateTime? RoleCreatedAt { get; init; } = DateTime.Now;

        public DateTime? RoleUpdatedAt { get; init; } = DateTime.Now;
    }
}
