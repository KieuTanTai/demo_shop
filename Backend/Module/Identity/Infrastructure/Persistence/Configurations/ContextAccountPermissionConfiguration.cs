using Identity.Models.Account;
using Identity.Models.Permission;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Persistence.Configurations
{
    public sealed class ContextAccountPermissionConfiguration
        : IEntityTypeConfiguration<AccountPermission>
    {
        public void Configure(EntityTypeBuilder<AccountPermission> entity)
        {
            entity.ToTable("account_permission");

            entity.HasKey(accountPermission => new
            {
                accountPermission.AccountId,
                accountPermission.PermissionId
            });

            entity.Property(accountPermission => accountPermission.AccountId)
                .HasColumnName("account_id")
                .IsRequired();

            entity.Property(accountPermission => accountPermission.PermissionId)
                .HasColumnName("permission_id")
                .IsRequired();

            entity.Property(accountPermission => accountPermission.AssignedAt)
                .HasColumnName("assigned_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            entity.HasOne<Account>()
                .WithMany()
                .HasForeignKey(accountPermission => accountPermission.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne<Permission>()
                .WithMany()
                .HasForeignKey(accountPermission => accountPermission.PermissionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}