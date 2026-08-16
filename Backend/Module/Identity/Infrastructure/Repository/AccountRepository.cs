using Identity.DBContext;
using Identity.Interfaces;
using Identity.Models.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.Persistence;

namespace Identity.Infrastructure.Repository
{
    public class AccountRepository(IdentityDbContext context) : IAccountRepository
    {
        private readonly IdentityDbContext _db = context;

        public async Task<IReadOnlyList<Account>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _db.Accounts.AsNoTracking().ToListAsync(cancellationToken: cancellationToken);

        public async Task<Account?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await _db.Accounts.AsNoTracking().FirstOrDefaultAsync(account => account.AccountId == id, cancellationToken: cancellationToken);

        public async Task<Account?> GetTrackedByIdAsync(Guid id, CancellationToken cancellationToken = default)
            => await _db.Accounts.FirstOrDefaultAsync(account => account.AccountId == id,
                cancellationToken: cancellationToken);
        
        public async Task<RecordBaseCursorPage<Account>> GetApplyPaging(Guid? cursor, int pageSize, CancellationToken cancellationToken = default)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(pageSize, 1);
            var accounts = _db.Accounts.AsNoTracking().OrderByDescending(account => account.AccountId).ToAsyncEnumerable();
            if (cursor.HasValue)
                accounts = accounts.Where(account => account.AccountId < cursor);

            var items = await accounts.Take(pageSize + 1).ToListAsync(cancellationToken: cancellationToken);
            var isHasMore = items.Count > pageSize;
            if (isHasMore)
                items.RemoveAt(items.Count - 1);

            Guid? nextCursor = isHasMore ? items[^1].AccountId : null;
            return new RecordBaseCursorPage<Account>(items, nextCursor, isHasMore);
        }

        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
            => await _db.Accounts.AnyAsync(account => account.AccountId == id, cancellationToken: cancellationToken); 

        public async Task AddAsync(Account account, CancellationToken cancellationToken = default)
        {if (string.IsNullOrWhiteSpace(account.AccountEmail))
                throw new ArgumentException("Account email is required.", nameof(account.AccountEmail));

            var isExisted = await _db.Accounts.AnyAsync(existedAccount => existedAccount.AccountEmail == account.AccountEmail,
                cancellationToken: cancellationToken);

            if (isExisted)
                throw new InvalidOperationException("Already existed!");

            await _db.Accounts.AddAsync(account, cancellationToken: cancellationToken);
        }
    }
}
