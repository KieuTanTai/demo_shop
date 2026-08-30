using Identity.Models.Account;

namespace Identity.Interfaces
{
    public interface IAccountHelper
    {
        bool IsEmailValid(string email);
        bool IsPasswordValid(string password);
        bool IsPhoneNumberValid(string phoneNumber);
        string GetPasswordHash(AccountModel account, string password);

        bool PasswordVerify(AccountModel account, string password, string hash);
    }
}