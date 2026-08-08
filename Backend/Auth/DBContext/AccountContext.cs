using Microsoft.EntityFrameworkCore;

public class AccountContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }

    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<AccountPermission> AccountPermissions { get; set; }

    public AccountContext(DbContextOptions options) : base(options)
    {
        // Accounts = new DbSet<Account>(this);
        // Roles = new DbSet<Role>(this);
        // Permissions = new DbSet<Permission>(this);
        // AccountRoles = new DbSet<AccountRole>(this);
        // RolePermissions = new DbSet<RolePermission>(this);
        // AccountPermissions = new DbSet<AccountPermission>(this);
    }
}