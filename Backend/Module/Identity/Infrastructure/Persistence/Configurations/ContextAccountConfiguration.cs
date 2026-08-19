using Identity.Models.Account;
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
        }
    }
}