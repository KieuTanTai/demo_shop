using Identity.Models.Account;
using Shared.Interfaces;
using Shared.Persistence;

namespace Identity.Interfaces.IRepository
{
    public interface IAccountRepository : IBaseReadRepository<Account>
    {
        Task<RecordBaseCursorPage<Account>> GetApplyPaging(Guid? cursor, int pageSize,
            CancellationToken cancellationToken = default);
        
        Task<Account> GetAccountByEmail(string email, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<Account>> GetAccountByPhoneNumber(string phoneNumber, CancellationToken cancellationToken = default);
        
        Task<RecordBaseCursorPage<Account>> GetApplyPagingByStatus(Guid? cursor, int pageSize, bool isActive,
            CancellationToken cancellationToken = default);
        
        Task<Guid> AddAsync(Account account, CancellationToken cancellationToken = default);
        
        Task<int> UpdateAsync(Account account, CancellationToken cancellationToken = default);
    }
}
