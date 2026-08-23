using Identity.Models.Account;
using Shared.Persistence;

namespace Identity.Interfaces.IApplication
{
    public interface IAccountApplication
    {
        Task<AccountModel> Register(string email, string password, CancellationToken cancellationToken = default);
        Task<AccountModel> Login(string email, string password, CancellationToken cancellationToken = default);
        Task<bool> Logout(CancellationToken cancellationToken = default);
        Task<bool> ChangePassword(string oldPassword, string newPassword, CancellationToken cancellationToken = default);
        Task<bool> UpdateProfile(AccountModel accountModel, CancellationToken cancellationToken = default);
        Task<bool> UpdateStatusAccount(Guid? accountId, string? email, CancellationToken cancellationToken = default);
        
        // Methods for adminstration
        Task<IReadOnlyList<AccountModel>> GetAllAccount(CancellationToken cancellationToken = default);
        Task<RecordBaseCursorPage<AccountModel>> GetApplyPaging(Guid? cursor, int pageSize, CancellationToken cancellationToken = default);
        Task<RecordBaseCursorPage<AccountModel>> GetApplyPagingByStatus(Guid? cursor, int pageSize, bool isActive, CancellationToken cancellationToken = default);
        Task<AccountModel> GetAccountByEmail(string email, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<AccountModel>> GetAccountByPhoneNumber(string phoneNumber, CancellationToken cancellationToken = default);
        
    }
}