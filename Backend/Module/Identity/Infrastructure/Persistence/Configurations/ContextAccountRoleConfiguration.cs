using Identity.Models.Account;
using Identity.Models.Role;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Persistence.Configurations
{
    public sealed class ContextAccountRoleConfiguration : IEntityTypeConfiguration<AccountRoleModel>
    {
        public void Configure(EntityTypeBuilder<AccountRoleModel> entity)
        {
            entity.ToTable("account_role");

            entity.HasKey(accountRole => new
            {
                accountRole.AccountId,
                accountRole.RoleId
            });

            entity.Property(accountRole => accountRole.AccountId)
                .HasColumnName("account_id")
                .IsRequired();

            entity.Property(accountRole => accountRole.RoleId)
                .HasColumnName("role_id")
                .IsRequired();

            entity.Property(accountRole => accountRole.AssignedAt)
                .HasColumnName("assigned_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            entity.HasOne<AccountModel>()
                .WithMany()
                .HasForeignKey(accountRole => accountRole.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne<RoleModel>()
                .WithMany()
                .HasForeignKey(accountRole => accountRole.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}