using Identity.Models.Permission;
using Identity.Models.Role;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Persistence.Configurations
{
    public sealed class ContextRoleConfiguration : IEntityTypeConfiguration<RoleModel>
    {
        public void Configure(EntityTypeBuilder<RoleModel> entity)
        {
            entity.ToTable("role");

            entity.HasKey(role => role.RoleId);

            entity.Property(role => role.RoleId)
                .HasColumnName("role_id")
                .ValueGeneratedOnAdd();

            entity.Property(role => role.RoleName)
                .HasColumnName("role_name")
                .HasMaxLength(150)
                .IsRequired();

            entity.HasIndex(role => role.RoleName)
                .IsUnique()
                .HasDatabaseName("idx_role_name");


            entity.Property(role => role.RoleDescription)
                .HasColumnName("role_description")
                .HasMaxLength(300);

            entity.Property(role => role.RoleIsActive)
                .HasColumnName("role_active")
                .HasDefaultValue(true)
                .IsRequired();

            entity.Property(role => role.RoleCreatedAt)
                .HasColumnName("role_created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            entity.Property(role => role.RoleUpdatedAt)
                .HasColumnName("role_updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();

            entity.HasMany(role => role.Permissions).WithMany().UsingEntity<RolePermissionModel>(
                rolePermission => rolePermission.HasOne<PermissionModel>().WithMany()
                    .HasForeignKey(rolePerm => rolePerm.PermissionId),
                rolePermission => rolePermission.HasOne<RoleModel>().WithMany().HasForeignKey(rolePerm => rolePerm.RoleId),
                rolePermission => {
                    rolePermission.ToTable("role_permission");
                    rolePermission.HasKey(rolePerm => new
                    {
                        rolePerm.RoleId,
                        rolePerm.PermissionId
                    });

                    rolePermission.Property(rolePerm => rolePerm.RoleId)
                        .HasColumnName("role_id");

                    rolePermission.Property(rolePerm => rolePerm.PermissionId)
                        .HasColumnName("permission_id");

                    rolePermission.Property(rolePerm => rolePerm.AssignedAt)
                        .HasColumnName("assigned_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP")
                        .ValueGeneratedOnAdd();
                });
        }
    }
}