using Identity.Models.Permission;
using Identity.Models.Role;

namespace Identity.Infrastructure.Cache
{
    public static class CacheRoleAndPermissionPool
    {
        // save role and permission
        //Readonly hash role
        public static HashSet<RoleModel> RoleList { get; private set; } = [];

        //Readonly hash permission
        public static HashSet<PermissionModel> PermissionList { get; private set; } = [];

        #region SETTER

        public static void SetRoleList(HashSet<RoleModel> roleList)
        {
            RoleList = roleList;
        }
        public static void SetPermissionList(HashSet<PermissionModel> permissionList)
        {
            PermissionList = permissionList;
        }

        #endregion
    }
}