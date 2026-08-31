namespace Identity.Utils.Enum
{
    public enum ESystemPermissionCode
    {
        // Product
        ProductRead,

        ProductCreate,

        ProductUpdate,

        ProductDelete,

        ProductSell,

        // Cart
        CartRead,

        CartAddItem,

        CartUpdateItem,

        CartRemoveItem,

        // Purchase
        PurchaseCreate,

        // Order
        OrderRead,

        OrderCreate,

        OrderUpdate,

        OrderDelete,

        // CustomerAccessPermissions
        CustomerRead,

        CustomerCreate,

        CustomerUpdate,

        CustomerDelete,

        // Role
        RoleRead,

        RoleCreate,

        RoleUpdate,

        RoleDelete,

        // Permission
        PermissionRead,

        PermissionCreate,

        PermissionUpdate,

        PermissionDelete,

        // Statistics
        StatisticsRead
    }
}