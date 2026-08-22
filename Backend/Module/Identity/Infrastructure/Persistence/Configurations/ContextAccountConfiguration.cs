using Identity.Models.Account;
using Identity.Models.Permission;
using Identity.Models.Role;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Persistence.Configurations
{
    public sealed class ContextAccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> entity)
        {
            entity.ToTable("account");

            entity.HasKey(account => account.AccountId);

            entity.Property(account => account.AccountId)
                .HasColumnName("account_id")
                .ValueGeneratedOnAdd();

            entity.Property(account => account.AccountEmail)
                .HasColumnName("account_email")
                .HasMaxLength(255)
                .IsRequired();

            entity.HasIndex(account => account.AccountEmail)
                .IsUnique();

            entity.Property(account => account.AccountPassword)
                .HasColumnName("account_password")
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(account => account.AccountPhone)
                .HasColumnName("account_phone")
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired(false);

            entity.Property(account => account.AccountIsActive)
                .HasColumnName("account_is_active")
                .HasDefaultValue(true)
                .IsRequired();

            entity.Property(account => account.AccountCreatedAt)
                .HasColumnName("account_created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            entity.Property(account => account.AccountUpdatedAt)
                .HasColumnName("account_updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();

            entity.HasMany(account => account.Roles).WithMany().UsingEntity<AccountRole>(
                right => right.HasOne<Role>().WithMany().HasForeignKey(role => role.RoleId)
                    .OnDelete(DeleteBehavior.Cascade),
                left => left.HasOne<Account>().WithMany().HasForeignKey(account => account.AccountId)
                    .OnDelete(DeleteBehavior.Cascade),
                join =>
                {
                    join.ToTable("account_role");
                    join.HasKey(accountRole => new
                    {
                        accountRole.AccountId,
                        accountRole.RoleId
                    });

                    join.Property(accountRole => accountRole.AccountId)
                        .HasColumnName("account_id");

                    join.Property(accountRole => accountRole.RoleId)
                        .HasColumnName("role_id");

                    join.Property(accountRole => accountRole.AssignedAt)
                        .HasColumnName("assigned_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP")
                        .ValueGeneratedOnAdd();
                });

            entity.HasMany(account => account.Permissions).WithMany().UsingEntity<AccountPermission>(
                right => right.HasOne<Permission>().WithMany().HasForeignKey(permission => permission.PermissionId)
                    .OnDelete(DeleteBehavior.Cascade),
                left => left.HasOne<Account>().WithMany().HasForeignKey(account => account.AccountId)
                    .OnDelete(DeleteBehavior.Cascade),
                join =>
                {
                    join.ToTable("account_permission");
                    join.HasKey(accountPermission => new
                    {
                        accountPermission.AccountId,
                        accountPermission.PermissionId
                    });

                    join.Property(accountPermission => accountPermission.AccountId)
                        .HasColumnName("account_id");

                    join.Property(accountPermission => accountPermission.PermissionId)
                        .HasColumnName("permission_id");

                    join.Property(accountPermission => accountPermission.AssignedAt)
                        .HasColumnName("assigned_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP")
                        .ValueGeneratedOnAdd();
                });
        }
    }
}