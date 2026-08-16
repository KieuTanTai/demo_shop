using Module.Identity.Models;

namespace Module.Identity.Interfaces;
public interface IAccountService
{
    Account CreateAccount(string email, string password);
}
