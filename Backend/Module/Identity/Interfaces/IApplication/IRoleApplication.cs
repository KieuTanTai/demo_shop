using Identity.Models.Role;

namespace Identity.Interfaces.IApplication
{
    public interface IRoleApplication
    {
        Task<List<RoleModel>> GetBaseRolesForUserAsync(Guid userId);
        Task<List<RoleModel>> GetAllRolesForUserAsync(string userId);
    }
}