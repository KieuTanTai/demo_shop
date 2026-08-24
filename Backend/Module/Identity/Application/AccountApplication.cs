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
        IBaseAssociativeRepository<AccountPermissionModel, Guid> accountPermissionRepository,
        IBaseAssociativeRepository<RolePermissionModel, Guid> rolePermissionRepository,
        IBaseAuthorizationRepository<RoleModel, Guid> roleRepository,
        IBaseAuthorizationRepository<PermissionModel, Guid> permissionRepository,
        IAccountHelper accountHelper) 
        : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository = accountRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IBaseAssociativeRepository<AccountRoleModel, Guid> _accountRoleRepository = accountRoleRepository;
        private readonly IBaseAssociativeRepository<AccountPermissionModel, Guid> _accountPermissionRepository = accountPermissionRepository;
        private readonly IBaseAssociativeRepository<RolePermissionModel, Guid> _rolePermissionRepository = rolePermissionRepository;
        private readonly IBaseAuthorizationRepository<RoleModel, Guid> _roleRepository = roleRepository;
        private readonly IBaseAuthorizationRepository<PermissionModel, Guid> _permissionRepository = permissionRepository;
        private readonly IAccountHelper _accountHelper = accountHelper;

        #region USER

        public async Task<AccountModel> Register(string email, string password, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
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