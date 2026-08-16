using Identity.Models.Account;
using Identity.Models.Permission;
using Identity.Models.Role;
using Microsoft.EntityFrameworkCore;

namespace Identity.DBContext
{
    public sealed class IdentityDbContext(DbContextOptions<IdentityDbContext> contextOptions) : DbContext(contextOptions)
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<AccountPermission> AccountPermissions { get; set; }
    }
}
