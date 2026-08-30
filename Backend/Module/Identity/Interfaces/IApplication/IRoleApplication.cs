using Identity.Models.Role;

namespace Identity.Interfaces.IApplication
{
    public interface IRoleApplication
    {
        Task<RoleModel> GetBaseRolesForUserAsync(CancellationToken cancellationToken = default);
    }
}