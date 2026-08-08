public interface IAccountModelFactory
{
    Account CreateAccount(string email, string password);

    Role CreateRole(string name, string? description = null);

    Permission CreatePermission(string name, string? description = null);

    AccountRole CreateAccountRole(Guid accountId, Guid roleId);

    RolePermission CreateRolePermission(Guid roleId, Guid permissionId);

    AccountPermission CreateAccountPermission(Guid accountId, Guid permissionId);
}
