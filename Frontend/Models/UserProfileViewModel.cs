using Shared.Enum;
using Shared.ModelHelper;

namespace Frontend.Models
{
    public class UserProfileViewModel(string? firstName, string? lastName, string? phoneNumber, string? avatarUrl, DateOnly? dateOfBirth, ESystemUserGender gender)
    {
        public string? FirstName { get; private set; } = firstName;
        public string? LastName { get; private set; } = lastName;
        public string? PhoneNumber { get; private set; } = phoneNumber;
        public string? AvatarUrl { get; private set; } = avatarUrl;
        public DateOnly? DateOfBirth { get; private set; } = dateOfBirth;
        public ESystemUserGender Gender { get; private set; } = gender;

        #region SET

        public void SetFirstName(string firstName)
        {
            FirstName = ModelFieldGuard.Required(firstName, 30, nameof(firstName));
        }

        public void SetLastName(string lastName)
        {
            LastName = ModelFieldGuard.Required(lastName, 30, nameof(lastName));
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            PhoneNumber = ModelFieldGuard.Required(phoneNumber, 10, nameof(phoneNumber));
        }

        public void SetAvatarUrl(string avatarUrl)
        {
            AvatarUrl = ModelFieldGuard.Required(avatarUrl, 255, nameof(avatarUrl));
        }

        public void SetDateOfBirth(DateOnly dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
        }

        public void SetGender(ESystemUserGender gender)
        {
            Gender = gender;
        }

        #endregion
    }
}