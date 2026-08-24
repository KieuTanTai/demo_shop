using Identity.Models.Account;
using Shared.Interfaces;
using Shared.Persistence;

namespace Identity.Interfaces.IRepository
{
    public interface IAccountRepository : IBaseReadRepository<AccountModel>, IBasePostRepository<AccountModel>
    {
        Task<RecordBaseCursorPage<AccountModel>> GetApplyPaging(Guid? cursor, int pageSize,
            CancellationToken cancellationToken = default);

        Task<AccountModel> GetAccountByEmail(string email, CancellationToken cancellationToken = default);

        Task<RecordBaseCursorPage<AccountModel>> GetAccountByPhoneNumber(Guid? cursor, string phoneNumber, int pageSize,
            CancellationToken cancellationToken = default);

        Task<RecordBaseCursorPage<AccountModel>> GetApplyPagingByStatus(Guid? cursor, int pageSize, bool isActive,
            CancellationToken cancellationToken = default);
    }
}