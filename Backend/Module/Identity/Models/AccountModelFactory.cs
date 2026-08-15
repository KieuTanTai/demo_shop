public class AccountModelFactory : IAccountModelFactory
{
    public Account CreateAccount(string email, string password)
    {
        var now = DateTime.UtcNow;

        return new Account
        {
            AccountId = Guid.NewGuid(),
            AccountEmail = email,
            AccountPassword = password,
            AccountLoginStatus = true,
            AccountCreatedAt = now,
            AccountUpdatedAt = now
        };
    }

    public Role CreateRole(string name, string? description = null)
    {
        var now = DateTime.UtcNow;

        return new Role
        {
            RoleId = Guid.NewGuid(),
            RoleName = name,
            RoleDescription = description,
            RoleActive = true,
            RoleCreatedAt = now,
            RoleUpdatedAt = now
        };
    }

    public Permission CreatePermission(string name, string? description = null)
    {
        return new Permission
        {
            PermissionId = Guid.NewGuid(),
            PermissionName = name,
            PermissionDescription = description,
            PermissionCreatedAt = DateTime.UtcNow
        };
    }

    public AccountRole CreateAccountRole(Guid accountId, Guid roleId)
    {
        return new AccountRole
        {
            AccountId = accountId,
            RoleId = roleId,
            AssignedAt = DateTime.UtcNow
        };
    }

    public RolePermission CreateRolePermission(Guid roleId, Guid permissionId)
    {
        return new RolePermission
        {
            RoleId = roleId,
            PermissionId = permissionId,
            AssignedAt = DateTime.UtcNow
        };
    }

    public AccountPermission CreateAccountPermission(Guid accountId, Guid permissionId)
    {
        return new AccountPermission
        {
            AccountId = accountId,
            PermissionId = permissionId,
            AssignedAt = DateTime.UtcNow
        };
    }
}
