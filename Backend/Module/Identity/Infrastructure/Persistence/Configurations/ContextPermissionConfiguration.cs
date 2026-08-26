using Identity.Models.Permission;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Persistence.Configurations
{
    public class ContextPermissionConfiguration : IEntityTypeConfiguration<PermissionModel>
    {
        public void Configure(EntityTypeBuilder<PermissionModel> entity)
        {
            entity.ToTable("permission");

            entity.HasKey(permission => permission.PermissionId);

            entity.Property(permission => permission.PermissionId)
                .HasColumnName("permission_id")
                .ValueGeneratedOnAdd();
            
            entity.Property(permission => permission.PermissionCode)
                .HasColumnName("permission_code")
                .HasMaxLength(50)
                .IsRequired();
            
            entity.HasIndex(permission => permission.PermissionCode)
                .IsUnique()
                .HasDatabaseName("idx_permission_code");

            entity.Property(permission => permission.PermissionName)
                .HasColumnName("permission_name")
                .HasMaxLength(150)
                .IsRequired();
            
            entity.Property(permission => permission.PermissionDescription)
                .HasColumnName("permission_description")
                .HasMaxLength(300);

            entity.Property(permission => permission.PermissionIsActive)
                .HasColumnName("permission_active")
                .HasDefaultValue(true)
                .IsRequired();

            entity.Property(permission => permission.PermissionCreatedAt)
                .HasColumnName("permission_created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            entity.Property(permission => permission.PermissionUpdatedAt)
                .HasColumnName("permission_updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
            
            entity.HasIndex(permission => permission.PermissionName)
                .IsUnique()
                .HasDatabaseName("idx_permission_name");
        }
    }
}