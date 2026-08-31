using System.ComponentModel.DataAnnotations;
using Identity.Models.Account;
using Identity.Utils.Enum;
using Shared.ModelHelper;

namespace Identity.Models.Profile
{
    public class UserProfileModel
    {
        public UserProfileModel(int userProfileId, Guid userProfileAccountId, string userProfileFirstName, string userProfileLastName, DateOnly userProfileBirthday, ESystemUserProfileGender userProfileGender,
            string userProfilePhoneNumber, string userProfileAvatar)
        {
            UserProfileId = userProfileId;
            UserProfileAccountId = userProfileAccountId;
            UserProfileFirstName = userProfileFirstName ?? throw new ArgumentNullException(nameof(userProfileFirstName));
            UserProfileLastName = userProfileLastName ?? throw new ArgumentNullException(nameof(userProfileLastName));
            UserProfileBirthday = userProfileBirthday;
            UserProfileGender = userProfileGender;
            UserProfilePhoneNumber = userProfilePhoneNumber ?? throw new ArgumentNullException(nameof(userProfilePhoneNumber));
            UserProfileAvatar = userProfileAvatar ?? throw new ArgumentNullException(nameof(userProfileAvatar));
        }

        public UserProfileModel(Guid userProfileAccountId, string userProfileFirstName, string userProfileLastName, DateOnly userProfileBirthday, ESystemUserProfileGender userProfileGender)
        {
            UserProfileAccountId = userProfileAccountId;
            UserProfileFirstName = userProfileFirstName ?? throw new ArgumentNullException(nameof(userProfileFirstName));
            UserProfileLastName = userProfileLastName ?? throw new ArgumentNullException(nameof(userProfileLastName));
            UserProfileBirthday = userProfileBirthday;
            UserProfileGender = userProfileGender;
        }


        public int UserProfileId { get; init; }
        public Guid UserProfileAccountId { get; init; }

        [MaxLength(30)]
        public string? UserProfileFirstName { get; private set; }

        [MaxLength(30)]
        public string? UserProfileLastName { get; private set; }

        public DateOnly UserProfileBirthday { get; private set; }
        public ESystemUserProfileGender UserProfileGender { get; private set; }

        [MaxLength(10)]
        public string? UserProfilePhoneNumber { get; private set; } = "";

        [MaxLength(255)]
        public string UserProfileAvatar { get; private set; } = "";

        public DateTime UserProfileCreatedAt { get; init; } = DateTime.Now;
        public DateTime UserProfileUpdatedAt { get; private set; } = DateTime.Now;

        public AccountModel Account { get; init; } = new();

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
            UserProfileBirthday = birthday;
            UserProfileUpdatedAt = DateTime.Now;
        }

        public void SetUserProfileGender(ESystemUserProfileGender gender)
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
            UserProfileAvatar = ModelFieldGuard.Required(avatar, 255, nameof(avatar));
            UserProfileUpdatedAt = DateTime.Now;
        }

        #endregion
    }
}