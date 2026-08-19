using Identity.Models.Role;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Persistence.Configurations
{
    public sealed class ContextRoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> entity)
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
                .IsUnique();

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
        }
    }
}