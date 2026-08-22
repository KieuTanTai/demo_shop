using Identity.Infrastructure.Persistence.DBContext;
using Identity.Interfaces.IRepository;
using Identity.Models.Account;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IReadOnlyList<Account>> GetAccountByPhoneNumber(string phoneNumber, CancellationToken cancellationToken = default)
            => await _db.Accounts.AsNoTracking().Where(account => account.AccountPhone == phoneNumber).ToListAsync(cancellationToken: cancellationToken);
        
        public async Task<Account> GetAccountByEmail(string email, CancellationToken cancellationToken = default)
        {
            var account = await _db.Accounts.FirstOrDefaultAsync(account => account.AccountEmail == email, cancellationToken: cancellationToken);
            return account ?? throw new ArgumentException("Account email is required.", nameof(email));
        }
        
        public async Task<RecordBaseCursorPage<Account>> GetApplyPaging(Guid? cursor, int pageSize, CancellationToken cancellationToken = default)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(pageSize, 1);
            var accounts = _db.Accounts.AsNoTracking().OrderByDescending(account => account.AccountId).ToAsyncEnumerable();
            if (cursor.HasValue)
                accounts = accounts.Where(account => account.AccountId < cursor);
            return await HelperApplyPaging.ApplyPaging(accounts, pageSize, account => account.AccountId, cancellationToken);
        }

        public async Task<RecordBaseCursorPage<Account>> GetApplyPagingByStatus(Guid? cursor, int pageSize,
            bool isActive, CancellationToken cancellationToken = default)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(pageSize, 1);
            var accounts = _db.Accounts.AsNoTracking().OrderByDescending(account => account.AccountId).ToAsyncEnumerable();
            if (cursor.HasValue)
                accounts = accounts.Where(account => account.AccountId < cursor);
            accounts = accounts.Where(account => account.AccountIsActive == isActive);
            return await HelperApplyPaging.ApplyPaging(accounts, pageSize, account => account.AccountId, cancellationToken);
        }
        
        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
            => await _db.Accounts.AnyAsync(account => account.AccountId == id, cancellationToken: cancellationToken); 

        public async Task<Guid> AddAsync(Account account, CancellationToken cancellationToken = default)
        {if (string.IsNullOrWhiteSpace(account.AccountEmail))
                throw new ArgumentException("Account email is required.", nameof(account.AccountEmail));

            var isExisted = await _db.Accounts.AnyAsync(existedAccount => existedAccount.AccountEmail == account.AccountEmail,
                cancellationToken: cancellationToken);

            if (isExisted)
                throw new InvalidOperationException("Already existed!");

            var result = await _db.Accounts.AddAsync(account, cancellationToken: cancellationToken);
            return result.Entity.AccountId;
        }

        public async Task<int> UpdateAsync(Account account, CancellationToken cancellationToken = default)
        {
            if (account.AccountId == Guid.Empty)
                throw new ArgumentException("Account id is required.", nameof(account.AccountId));
            var existedAccount = await _db.Accounts.FirstOrDefaultAsync(existedAccount => existedAccount.AccountId == account.AccountId, cancellationToken: cancellationToken);
            if (existedAccount is null)
                throw new InvalidOperationException("Account not found!");
            _db.Accounts.Update(account);
            return await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
