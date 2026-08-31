using Identity.Utils.Enum;

namespace Identity.Utils
{
    public static class ESystemRolePermissions
    {
        #region CustomerAccessPermissions

        private static readonly HashSet<ESystemPermissionCode> Customer =
        [
            ESystemPermissionCode.ProductRead,

            ESystemPermissionCode.CartRead,
            ESystemPermissionCode.CartAddItem,
            ESystemPermissionCode.CartUpdateItem,
            ESystemPermissionCode.CartRemoveItem,

            ESystemPermissionCode.PurchaseCreate
        ];

        #endregion

        #region Employee

        private static readonly HashSet<ESystemPermissionCode> Employee =
        [
            ESystemPermissionCode.ProductRead,
            ESystemPermissionCode.ProductSell,

            ESystemPermissionCode.RoleRead,
            ESystemPermissionCode.PermissionRead
        ];

        #endregion

        #region Assistant

        private static readonly HashSet<ESystemPermissionCode> Assistant =
        [
            ESystemPermissionCode.ProductRead,
            ESystemPermissionCode.ProductSell,

            ESystemPermissionCode.RoleRead,
            ESystemPermissionCode.PermissionRead,

            ESystemPermissionCode.StatisticsRead
        ];

        #endregion

        #region Manager

        private static readonly HashSet<ESystemPermissionCode> Manager =
        [
            // Product
            ESystemPermissionCode.ProductRead,
            ESystemPermissionCode.ProductCreate,
            ESystemPermissionCode.ProductUpdate,
            ESystemPermissionCode.ProductDelete,

            // CustomerAccessPermissions
            ESystemPermissionCode.CustomerRead,
            ESystemPermissionCode.CustomerCreate,
            ESystemPermissionCode.CustomerUpdate,
            ESystemPermissionCode.CustomerDelete,

            // Order
            ESystemPermissionCode.OrderRead,
            ESystemPermissionCode.OrderCreate,
            ESystemPermissionCode.OrderUpdate,
            ESystemPermissionCode.OrderDelete,

            // Role
            ESystemPermissionCode.RoleRead,
            ESystemPermissionCode.RoleUpdate,

            // Permission
            ESystemPermissionCode.PermissionRead,
            ESystemPermissionCode.PermissionUpdate,

            // Statistics
            ESystemPermissionCode.StatisticsRead
        ];

        #endregion

        #region Admin

        private static readonly HashSet<ESystemPermissionCode> Admin =
        [
            // Product
            ESystemPermissionCode.ProductRead,
            ESystemPermissionCode.ProductCreate,
            ESystemPermissionCode.ProductUpdate,
            ESystemPermissionCode.ProductDelete,

            // Cart
            ESystemPermissionCode.CartRead,
            ESystemPermissionCode.CartAddItem,
            ESystemPermissionCode.CartUpdateItem,
            ESystemPermissionCode.CartRemoveItem,

            // Order
            ESystemPermissionCode.OrderRead,
            ESystemPermissionCode.OrderCreate,
            ESystemPermissionCode.OrderUpdate,
            ESystemPermissionCode.OrderDelete,

            // CustomerAccessPermissions
            ESystemPermissionCode.CustomerRead,
            ESystemPermissionCode.CustomerCreate,
            ESystemPermissionCode.CustomerUpdate,
            ESystemPermissionCode.CustomerDelete,

            // Role
            ESystemPermissionCode.RoleRead,
            ESystemPermissionCode.RoleCreate,
            ESystemPermissionCode.RoleUpdate,
            ESystemPermissionCode.RoleDelete,

            // Permission
            ESystemPermissionCode.PermissionRead,
            ESystemPermissionCode.PermissionCreate,
            ESystemPermissionCode.PermissionUpdate,
            ESystemPermissionCode.PermissionDelete,

            // Statistics
            ESystemPermissionCode.StatisticsRead
        ];

        #endregion

        #region Helper

        private static IReadOnlySet<ESystemPermissionCode> GetPermissions(
            ESystemRoleCode roleCode)
        {
            return roleCode switch
            {
                ESystemRoleCode.Customer => Customer,
                ESystemRoleCode.Employee => Employee,
                ESystemRoleCode.Assistant => Assistant,
                ESystemRoleCode.Manager => Manager,
                ESystemRoleCode.Admin => Admin,
                _ => throw new ArgumentOutOfRangeException(nameof(roleCode), roleCode, null)
            };
        }

        #endregion
    }
}