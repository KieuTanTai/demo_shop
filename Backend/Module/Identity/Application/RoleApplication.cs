using Identity.Interfaces.IApplication;
using Identity.Interfaces.IRepository;
using Identity.Models.Role;
using Identity.Utils.Enum;
using Shared.Interfaces;

namespace Identity.Application
{
    public class RoleApplication( IUnitOfWork unitOfWork, IBaseAuthorizationRepository<RoleModel, ESystemRoleCode> roleRepository, 
        IAccountRepository accountRepository) : IRoleApplication
    {
        private readonly IAccountRepository _accountRepository = accountRepository;
        private readonly IBaseAuthorizationRepository<RoleModel, ESystemRoleCode> _roleRepository = roleRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<IReadOnlyList<RoleModel>> GetBaseRolesForUserAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _roleRepository.GetByCodeAsync(ESystemRoleCode.Customer, cancellationToken);
                if (result.Count == 0)
                    throw new InvalidOperationException("base role not found!");
                return result;
            }
            catch (OperationCanceledException canceledException)
            {
                throw new OperationCanceledException("Operation was canceled.", canceledException);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error occurred while fetching base roles for user: {ex.Message}");
            }
            throw new Exception("Failed to fetch base roles for user.");
        }
    }
}