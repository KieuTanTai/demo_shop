using Identity.Models.Account;
using Identity.Models.Permission;
using Identity.Models.Role;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Persistence.DBContext
{
    public sealed class IdentityDbContext(DbContextOptions<IdentityDbContext> contextOptions)
        : DbContext(contextOptions)
    {
        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<PermissionModel> Permissions { get; set; }

        public DbSet<AccountRoleModel> AccountRoles { get; set; }
        public DbSet<RolePermissionModel> RolePermissions { get; set; }
        public DbSet<AccountPermissionModel> AccountPermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasCharSet("utf8mb4").UseCollation("utf8mb4_unicode_ci");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
        }
    }
}