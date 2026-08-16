using Identity.Models.Account;

namespace Identity.Interfaces
{
    public interface IAccountService
    {
        Account CreateAccount(string email, string password);
    }
}
