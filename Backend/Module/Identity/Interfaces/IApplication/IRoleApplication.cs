using Identity.Models.Role;

namespace Identity.Interfaces.IApplication
{
    public interface IRoleApplication
    {
        Task<IReadOnlyList<RoleModel>> GetBaseRolesForUserAsync(CancellationToken cancellationToken = default);
    }
}