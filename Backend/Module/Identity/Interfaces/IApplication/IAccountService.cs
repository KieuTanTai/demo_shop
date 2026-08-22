using Identity.Models.Account;

namespace Identity.Interfaces.IApplication
{
    public interface IAccountService
    {
        AccountModel CreateAccount(string email, string password);
    }
}