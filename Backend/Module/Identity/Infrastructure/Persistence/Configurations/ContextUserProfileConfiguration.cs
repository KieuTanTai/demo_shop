using Identity.Models.Profile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infrastructure.Persistence.Configurations
{
    public sealed class ContextUserProfileConfiguration : IEntityTypeConfiguration<UserProfileModel>
    {
        public void Configure(EntityTypeBuilder<UserProfileModel> entity)
        {
            // Configuration logic for UserProfileModel
            entity.ToTable("user_profile");
            entity.HasKey(userProfile => userProfile.UserProfileId);

            entity.Property(userProfile => userProfile.UserProfileId)
                .HasColumnName("user_profile_id")
                .ValueGeneratedOnAdd();

            entity.Property(userProfile => userProfile.UserProfileAccountId)
                .HasColumnName("user_profile_account_id")
                .IsRequired();

            entity.Property(userProfile => userProfile.UserProfileFirstName)
                .HasColumnName("user_profile_first_name")
                .HasMaxLength(30);

            entity.Property(userProfile => userProfile.UserProfileLastName)
                .HasColumnName("user_profile_last_name")
                .HasMaxLength(30);

            entity.Property(userProfile => userProfile.UserProfileDateOfBirth)
                .HasColumnName("user_profile_date_of_birth");

            entity.Property(userProfile => userProfile.UserProfileGender)
                .HasColumnName("user_profile_gender")
                .HasConversion<string>()
                .HasMaxLength(20);

            entity.Property(userProfile => userProfile.UserProfilePhoneNumber)
                .HasColumnName("user_profile_phone_number")
                .HasMaxLength(10);

            entity.Property(userProfile => userProfile.UserProfileAvatarUrl)
                .HasColumnName("user_profile_avatar_url")
                .HasMaxLength(255);

            entity.Property(userProfile => userProfile.UserProfileBackgroundUrl)
                .HasColumnName("user_profile_background_url")
                .HasMaxLength(255);

            entity.Property(userProfile => userProfile.UserProfileCreatedAt)
                .HasColumnName("user_profile_created_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();

            entity.Property(userProfile => userProfile.UserProfileUpdatedAt)
                .HasColumnName("user_profile_updated_at")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
