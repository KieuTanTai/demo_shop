using Identity.Models.Permission;
using Identity.Models.Role;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Persistence.Configurations
{
    public sealed class ContextRolePermissionConfiguration
        : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> entity)
        {
            entity.ToTable("role_permission");

            entity.HasKey(rolePermission => new
            {
                rolePermission.RoleId,
                rolePermission.PermissionId
            });

            entity.Property(rolePermission => rolePermission.RoleId)
                .HasColumnName("role_id")
                .IsRequired();

            entity.Property(rolePermission => rolePermission.PermissionId)
                .HasColumnName("permission_id")
                .IsRequired();

            entity.Property(rolePermission => rolePermission.AssignedAt)
                .HasColumnName("assigned_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            entity.HasOne<Role>()
                .WithMany()
                .HasForeignKey(rolePermission => rolePermission.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne<Permission>()
                .WithMany()
                .HasForeignKey(rolePermission => rolePermission.PermissionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}