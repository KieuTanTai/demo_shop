using Identity.Models.Account;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Interfaces;
using Shared.Persistence;

namespace Identity.Interfaces
{
    public interface IAccountRepository : IBaseReadRepository<Account>
    {
        Task<RecordBaseCursorPage<Account>> GetApplyPaging(Guid? cursor, int pageSize,
            CancellationToken cancellationToken = default);
        
        Task AddAsync(Account account, CancellationToken cancellationToken = default);
    }
}
