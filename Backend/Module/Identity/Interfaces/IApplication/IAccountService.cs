using Identity.Models.Account;

namespace Identity.Interfaces.IApplication
{
    public interface IAccountService
    {
        Account CreateAccount(string email, string password);
    }
}
