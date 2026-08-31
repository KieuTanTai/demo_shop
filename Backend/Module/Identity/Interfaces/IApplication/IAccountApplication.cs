using Identity.Models.Account;

namespace Identity.Interfaces.IApplication
{
    public interface IAccountApplication
    {
        Task<AccountModel> RegisterAsync(string email, string password, CancellationToken cancellationToken = default);
        Task<AccountModel> LoginAsync(string email, string password, CancellationToken cancellationToken = default);
        Task<bool> LogoutAsync(string email, CancellationToken cancellationToken = default);
        Task<int> ChangePasswordAsync(string email, string oldPassword, string newPassword, CancellationToken cancellationToken = default);
        Task<int> InactiveAccountAsync(Guid? accountId, string? email, CancellationToken cancellationToken = default);

        // Methods for admins
        // Task<IReadOnlyList<AccountModel>> GetAllAccountAsync(CancellationToken cancellationToken = default);
        // Task<RecordBaseCursorPage<AccountModel>> GetApplyPagingAsync(Guid? cursor, int pageSize, CancellationToken cancellationToken = default);
        // Task<RecordBaseCursorPage<AccountModel>> GetApplyPagingByStatusAsync(Guid? cursor, int pageSize, bool isActive, CancellationToken cancellationToken = default);
        // Task<AccountModel> GetAccountByEmailAsync(string email, CancellationToken cancellationToken = default);
        // Task<RecordBaseCursorPage<AccountModel>> GetAccountByPhoneNumberAsync(Guid? cursor, string phoneNumber, int pageSize, CancellationToken cancellationToken = default);
    }
}