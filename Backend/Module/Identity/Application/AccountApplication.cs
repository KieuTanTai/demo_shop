using Identity.Interfaces;
using Identity.Interfaces.IApplication;
using Identity.Interfaces.IRepository;
using Identity.Models.Account;
using Identity.Models.Permission;
using Identity.Models.Role;
using Shared.Interfaces;
using Shared.Persistence;

namespace Identity.Application
{
    public class AccountApplication(
        IAccountRepository accountRepository,
        IUnitOfWork unitOfWork,
        IBaseAssociativeRepository<AccountRoleModel, Guid> accountRoleRepository,
        IBaseAssociativeRepository<AccountAdditionalPermissionModel, Guid> accountPermissionRepository,
        IBaseAssociativeRepository<RolePermissionModel, Guid> rolePermissionRepository,
        IBaseAuthorizationRepository<RoleModel> roleRepository,
        IBaseAuthorizationRepository<PermissionModel> permissionRepository,
        IAccountHelper accountHelper) 
        : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository = accountRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IBaseAssociativeRepository<AccountRoleModel, Guid> _accountRoleRepository = accountRoleRepository;
        private readonly IBaseAssociativeRepository<AccountAdditionalPermissionModel, Guid> _accountPermissionRepository = accountPermissionRepository;
        private readonly IBaseAssociativeRepository<RolePermissionModel, Guid> _rolePermissionRepository = rolePermissionRepository;
        private readonly IBaseAuthorizationRepository<RoleModel> _roleRepository = roleRepository;
        private readonly IBaseAuthorizationRepository<PermissionModel> _permissionRepository = permissionRepository;
        private readonly IAccountHelper _accountHelper = accountHelper;

        #region USER

        public async Task<AccountModel> Register(string email, string password, CancellationToken cancellationToken = default)
        {
            var existedAccount = await _accountRepository.GetAccountByEmail(email, cancellationToken);
            if (existedAccount != null)
                throw new ArgumentException("AccountModel email is existed.", nameof(email));
            if (!_accountHelper.IsPasswordValid(password))
                throw new ArgumentException("AccountModel password is invalid.", nameof(password));
            if (!_accountHelper.IsEmailValid(email))
                throw new ArgumentException("AccountModel email is invalid.", nameof(email));
            
            var accountModel = new AccountModel(email, password);
            var hashedPassword = _accountHelper.GetPasswordHash(accountModel, password);

            try
            {
                //! TODO: create method for get role and permission for registered account, like using role service, permission service for get roles, perms, and write new method for batch update
                await _accountRepository.AddAsync(accountModel, cancellationToken);
                
                var result = _unitOfWork.SaveChangesAsync(cancellationToken);
                return accountModel;
            }
            catch(OperationCanceledException canceledException)
            {
                throw new OperationCanceledException("Operation was canceled.", canceledException);
                
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Failed to add account.", e);
            }
        }
        
        
        public async Task<AccountModel> Login(string email, string password, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        
        public async Task<bool> Logout(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        
        public async Task<bool> ChangePassword(string oldPassword, string newPassword, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        
        public async Task<bool> UpdateStatusAccount(Guid accountId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        
        public async Task<bool> UpdateProfile(AccountModel accountModel, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        
        public async Task<bool> UpdateStatusAccount(Guid? accountId, string? email, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ADMIN
        
        public async Task<IReadOnlyList<AccountModel>> GetAllAccount(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        
        public async Task<RecordBaseCursorPage<AccountModel>> GetApplyPaging(Guid? cursor, int pageSize, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        
        public async Task<RecordBaseCursorPage<AccountModel>> GetApplyPagingByStatus(Guid? cursor, int pageSize, bool isActive, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        
        public async Task<AccountModel> GetAccountByEmail(string email, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        
        public async Task<RecordBaseCursorPage<AccountModel>> GetAccountByPhoneNumber(Guid? cursor, string phoneNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}