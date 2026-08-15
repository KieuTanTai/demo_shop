public class AccountService : IAccountService
{
    private readonly IAccountRepository accountRepository;
    private readonly IAccountModelFactory accountModelFactory;

    public AccountService(
        IAccountRepository accountRepository,
        IAccountModelFactory accountModelFactory)
    {
        this.accountRepository = accountRepository;
        this.accountModelFactory = accountModelFactory;
    }

    public Account CreateAccount(string email, string password)
    {
        return accountModelFactory.CreateAccount(email, password);
    }
}
