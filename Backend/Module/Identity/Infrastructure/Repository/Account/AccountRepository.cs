using Identity.Infrastructure.Persistence.DBContext;
using Identity.Interfaces.IRepository;
using Identity.Models.Account;
using Microsoft.EntityFrameworkCore;
using Shared.Persistence;

namespace Identity.Infrastructure.Repository.Account
{
    public class AccountRepository(IdentityDbContext context) : IAccountRepository
    {
        private readonly IdentityDbContext _db = context;

        #region GET

        public async Task<IReadOnlyList<AccountModel>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            return await _db.Accounts.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<AccountModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _db.Accounts.AsNoTracking()
                .FirstOrDefaultAsync(account => account.AccountId == id, cancellationToken);
        }

        public async Task<AccountModel?> GetTrackedByIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _db.Accounts.FirstOrDefaultAsync(account => account.AccountId == id,
                cancellationToken);
        }

        public async Task<RecordBaseCursorPage<AccountModel>> GetAccountByPhoneNumber(Guid? cursor, string phoneNumber, int pageSize,
            CancellationToken cancellationToken = default)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(pageSize, 1);   
            var accounts = _db.Accounts.AsNoTracking().OrderByDescending(account => account.AccountId)
                .ToAsyncEnumerable();
            if (cursor.HasValue)
                accounts = accounts.Where(account => account.AccountId < cursor);
            accounts = accounts.Where(account => account.AccountPhoneNumber == phoneNumber);
            return await SharedGetApplyPagingRepository.ApplyPaging(accounts, pageSize, account => account.AccountId,
                cancellationToken);
        }

        public async Task<AccountModel> GetAccountByEmail(string email,
            CancellationToken cancellationToken = default)
        {
            var account =
                await _db.Accounts.FirstOrDefaultAsync(account => account.AccountEmail == email, cancellationToken);

            return account ?? throw new ArgumentException("AccountModel email is required.", nameof(email));
        }

        public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _db.Accounts.AnyAsync(account => account.AccountId == id, cancellationToken);
        }

        // Paging methods
        public async Task<RecordBaseCursorPage<AccountModel>> GetApplyPaging(Guid? cursor, int pageSize,
            CancellationToken cancellationToken = default)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(pageSize, 1);
            var accounts = _db.Accounts.AsNoTracking().OrderByDescending(account => account.AccountId)
                .ToAsyncEnumerable();

            if (cursor.HasValue)
            {
                accounts = accounts.Where(account => account.AccountId < cursor);
            }

            return await SharedGetApplyPagingRepository.ApplyPaging(accounts, pageSize, account => account.AccountId,
                cancellationToken);
        }

        public async Task<RecordBaseCursorPage<AccountModel>> GetApplyPagingByStatus(Guid? cursor,
            int pageSize,
            bool isActive, CancellationToken cancellationToken = default)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(pageSize, 1);
            var accounts = _db.Accounts.AsNoTracking().OrderByDescending(account => account.AccountId)
                .ToAsyncEnumerable();

            if (cursor.HasValue)
            {
                accounts = accounts.Where(account => account.AccountId < cursor);
            }

            accounts = accounts.Where(account => account.AccountIsActive == isActive);
            return await SharedGetApplyPagingRepository.ApplyPaging(accounts, pageSize, account => account.AccountId,
                cancellationToken);
        }

        #endregion

        #region POST

        public async Task<Guid> AddAsync(AccountModel accountModel, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(accountModel.AccountEmail))
            {
                throw new ArgumentException("AccountModel email is required.", nameof(accountModel.AccountEmail));
            }

            var isExisted = await _db.Accounts.AnyAsync(
                existedAccount => existedAccount.AccountEmail == accountModel.AccountEmail,
                cancellationToken);

            if (isExisted)
            {
                throw new InvalidOperationException("Already existed!");
            }

            var result = await _db.Accounts.AddAsync(accountModel, cancellationToken);
            await _db.SaveChangesAsync(cancellationToken);
            return result.Entity.AccountId;
        }

        public async Task<int> UpdateAsync(AccountModel accountModel,
            CancellationToken cancellationToken = default)
        {
            if (accountModel.AccountId == Guid.Empty)
            {
                throw new ArgumentException("AccountModel id is required.", nameof(accountModel.AccountId));
            }

            var existedAccount =
                await _db.Accounts.FirstOrDefaultAsync(existedAccount => existedAccount.AccountId == accountModel.AccountId,
                    cancellationToken);

            if (existedAccount is null)
            {
                throw new InvalidOperationException("AccountModel not found!");
            }

            _db.Accounts.Update(accountModel);
            return await _db.SaveChangesAsync(cancellationToken);
        }

        #endregion
    }
}