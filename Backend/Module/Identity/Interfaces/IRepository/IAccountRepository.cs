using Identity.Models.Account;
using Shared.Interfaces;
using Shared.Persistence;

namespace Identity.Interfaces.IRepository
{
    public interface IAccountRepository : IBaseReadRepository<AccountModel, Guid>, IBasePostRepository<AccountModel>
    {
        Task<RecordBaseCursorPage<AccountModel>> GetApplyPagingAsync(Guid? cursor, int pageSize,
            CancellationToken cancellationToken = default);

        Task<AccountModel> GetAccountByEmailAsync(string email, CancellationToken cancellationToken = default);

        Task<AccountModel> GetTrackedAccountByEmailAsync(string email, CancellationToken cancellationToken = default);

        Task<RecordBaseCursorPage<AccountModel>> GetApplyPagingByStatusAsync(Guid? cursor, int pageSize, bool isActive,
            CancellationToken cancellationToken = default);
    }
}