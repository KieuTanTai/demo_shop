using Identity.Interfaces;
using Identity.Interfaces.IApplication;
using Identity.Interfaces.IRepository;
using Identity.Models.Account;
using Identity.Models.Permission;
using Identity.Models.Role;
using Identity.Utils.Enum;
using Shared.Interfaces;
using Shared.Persistence;

namespace Identity.Application
{
    public class AccountApplication(
        IUnitOfWork unitOfWork,
        IAccountRepository accountRepository,
        IBaseAssociativeRepository<AccountRoleModel, Guid> accountRoleRepository,
        IBaseAssociativeRepository<AccountAdditionalPermissionModel, Guid> accountPermissionRepository,
        IBaseAssociativeRepository<RolePermissionModel, Guid> rolePermissionRepository,
        IBaseAuthorizationRepository<RoleModel, ESystemRoleCode> roleRepository,
        IBaseAuthorizationRepository<PermissionModel, ESystemPermissionCode> permissionRepository,
        IRoleApplication roleApplication,
        IAccountHelper accountHelper)
        : IAccountApplication
    {
        private readonly IAccountHelper _accountHelper = accountHelper;

        private readonly IBaseAssociativeRepository<AccountAdditionalPermissionModel, Guid> _accountPermissionRepository = accountPermissionRepository;

        private readonly IAccountRepository _accountRepository = accountRepository;

        private readonly IBaseAssociativeRepository<AccountRoleModel, Guid> _accountRoleRepository = accountRoleRepository;

        private readonly IBaseAuthorizationRepository<PermissionModel, ESystemPermissionCode> _permissionRepository = permissionRepository;

        private readonly IRoleApplication _roleApplication = roleApplication;

        private readonly IBaseAssociativeRepository<RolePermissionModel, Guid> _rolePermissionRepository = rolePermissionRepository;

        private readonly IBaseAuthorizationRepository<RoleModel, ESystemRoleCode> _roleRepository = roleRepository;

        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        #region USER

        public async Task<AccountModel> RegisterAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            var existedAccount = await _accountRepository.GetAccountByEmail(email, cancellationToken);
            if (existedAccount != null)
            {
                throw new ArgumentException("AccountModel email is existed.", nameof(email));
            }
            if (!_accountHelper.IsPasswordValid(password))
            {
                throw new ArgumentException("AccountModel password is invalid.", nameof(password));
            }
            if (!_accountHelper.IsEmailValid(email))
            {
                throw new ArgumentException("AccountModel email is invalid.", nameof(email));
            }

            var accountModel = new AccountModel(email, password);
            var hashedPassword = _accountHelper.GetPasswordHash(accountModel, password);
            accountModel.SetHashedPassword(hashedPassword);

            try
            {
                var baseRole = await _roleApplication.GetBaseRolesForUserAsync(cancellationToken);
                var accountRoles = baseRole.Select(role => new AccountRoleModel(accountModel.AccountId, role.RoleId)).ToList();
                await _accountRepository.AddAsync(accountModel, cancellationToken);
                await _accountRoleRepository.AddRangeAsync(accountRoles, cancellationToken);
                var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
                return accountModel;
            }
            catch (OperationCanceledException canceledException)
            {
                throw new OperationCanceledException("Operation was canceled.", canceledException);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Failed to add account.", e);
            }
        }


        public async Task<AccountModel> LoginAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LogoutAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ChangePasswordAsync(string oldPassword, string newPassword, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateStatusAccountAsync(Guid accountId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateProfileAsync(AccountModel accountModel, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateStatusAccountAsync(Guid? accountId, string? email, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ADMIN

        public async Task<IReadOnlyList<AccountModel>> GetAllAccountAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<RecordBaseCursorPage<AccountModel>> GetApplyPagingAsync(Guid? cursor, int pageSize, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<RecordBaseCursorPage<AccountModel>> GetApplyPagingByStatusAsync(Guid? cursor, int pageSize, bool isActive, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountModel> GetAccountByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<RecordBaseCursorPage<AccountModel>> GetAccountByPhoneNumberAsync(Guid? cursor, string phoneNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}