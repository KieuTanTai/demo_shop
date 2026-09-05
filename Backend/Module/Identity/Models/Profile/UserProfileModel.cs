using System.ComponentModel.DataAnnotations;
using Shared.Enum;
using Shared.ModelHelper;

namespace Identity.Models.Profile
{
    public class UserProfileModel
    {
        public UserProfileModel(int userProfileId, Guid userProfileAccountId, string userProfileFirstName, string userProfileLastName, DateOnly userProfileBirthday, ESystemUserGender userProfileGender,
            string userProfilePhoneNumber, string userProfileAvatar)
        {
            UserProfileId = userProfileId;
            UserProfileAccountId = userProfileAccountId;
            UserProfileFirstName = userProfileFirstName ?? throw new ArgumentNullException(nameof(userProfileFirstName));
            UserProfileLastName = userProfileLastName ?? throw new ArgumentNullException(nameof(userProfileLastName));
            UserProfileDateOfBirth = userProfileBirthday;
            UserProfileGender = userProfileGender;
            UserProfilePhoneNumber = userProfilePhoneNumber ?? throw new ArgumentNullException(nameof(userProfilePhoneNumber));
            UserProfileAvatarUrl = userProfileAvatar ?? throw new ArgumentNullException(nameof(userProfileAvatar));
        }

        public UserProfileModel(Guid userProfileAccountId, string userProfileFirstName, string userProfileLastName, DateOnly userProfileBirthday, ESystemUserGender userProfileGender)
        {
            UserProfileAccountId = userProfileAccountId;
            UserProfileFirstName = userProfileFirstName ?? throw new ArgumentNullException(nameof(userProfileFirstName));
            UserProfileLastName = userProfileLastName ?? throw new ArgumentNullException(nameof(userProfileLastName));
            UserProfileDateOfBirth = userProfileBirthday;
            UserProfileGender = userProfileGender;
        }


        public UserProfileModel(Guid userProfileAccountId)
        {
            UserProfileAccountId = userProfileAccountId;
        }

        public int UserProfileId { get; init; }
        public Guid UserProfileAccountId { get; init; }

        [MaxLength(30)]
        public string? UserProfileFirstName { get; private set; } = "";

        [MaxLength(30)]
        public string? UserProfileLastName { get; private set; } = "";

        public DateOnly? UserProfileDateOfBirth { get; private set; }
        public ESystemUserGender UserProfileGender { get; private set; }

        [MaxLength(10)]
        public string? UserProfilePhoneNumber { get; private set; } = "";

        [MaxLength(255)]
        public string UserProfileAvatarUrl { get; private set; } = "";

        public DateTime UserProfileCreatedAt { get; init; } = DateTime.Now;
        public DateTime UserProfileUpdatedAt { get; private set; } = DateTime.Now;

        #region SET

        public void SetUserProfileFirstName(string firstName)
        {
            UserProfileFirstName = ModelFieldGuard.Required(firstName, 100, nameof(firstName));
            UserProfileUpdatedAt = DateTime.Now;
        }

        public void SetUserProfileLastName(string lastName)
        {
            UserProfileLastName = ModelFieldGuard.Required(lastName, 100, nameof(lastName));
            UserProfileUpdatedAt = DateTime.Now;
        }

        public void SetUserProfileBirthday(DateOnly birthday)
        {
            UserProfileDateOfBirth = birthday;
            UserProfileUpdatedAt = DateTime.Now;
        }

        public void SetUserProfileGender(ESystemUserGender gender)
        {
            UserProfileGender = gender;
            UserProfileUpdatedAt = DateTime.Now;
        }

        public void SetUserProfilePhoneNumber(string phoneNumber)
        {
            UserProfilePhoneNumber = ModelFieldGuard.Required(phoneNumber, 10, nameof(phoneNumber));
            UserProfileUpdatedAt = DateTime.Now;
        }

        public void SetUserProfileAvatar(string avatar)
        {
            UserProfileAvatarUrl = ModelFieldGuard.Required(avatar, 255, nameof(avatar));
            UserProfileUpdatedAt = DateTime.Now;
        }

        #endregion
    }
}