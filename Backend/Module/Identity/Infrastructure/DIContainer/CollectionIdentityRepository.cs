using Identity.Infrastructure.Persistence.DBContext;
using Identity.Infrastructure.Repository;
using Identity.Infrastructure.Repository.Account;
using Identity.Infrastructure.Repository.Permission;
using Identity.Infrastructure.Repository.Role;
using Identity.Interfaces.IRepository;
using Identity.Models.Account;
using Identity.Models.Permission;
using Identity.Models.Role;
using Identity.Utils.Enum;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;

namespace Identity.Infrastructure.DIContainer
{
    public static class CollectionIdentityRepository
    {
        public static IServiceCollection AddIdentityRepositoryCollection(this IServiceCollection services,
            IConfiguration configuration, IHostEnvironment environment)
        {
            #region CONFIG

            var connectionString = configuration.GetConnectionString("Identity")
                                   ?? throw new InvalidOperationException(
                                       "Connection string 'Identity' was not found.");

            services.AddDbContext<IdentityDbContext>(options => {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

                // options.EnableServiceProviderCaching();
                options.EnableThreadSafetyChecks();

                if (environment.IsDevelopment())
                {
                    options.EnableDetailedErrors()
                        .EnableSensitiveDataLogging()
                        .LogTo(Console.WriteLine, LogLevel.Information);
                }
            });

            #endregion

            #region REPOSITORY
            
            services.AddScoped<IUnitOfWork, EfIdentityUnitOfWork>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IBaseAuthorizationRepository<RoleModel, ESystemRoleCode>, RoleRepository>();
            services.AddScoped<IBaseAuthorizationRepository<PermissionModel, ESystemPermissionCode>, PermissionRepository>();
            services.AddScoped<IBaseAssociativeRepository<AccountAdditionalPermissionModel, Guid>, AccountAdditionalPermissionRepository>();
            services.AddScoped<IBaseAssociativeRepository<AccountRoleModel, Guid>, AccountRoleRepository>();
            services.AddScoped<IBaseAssociativeRepository<RolePermissionModel, Guid>, RolePermissionRepository>();

            #endregion

            return services;
        }
    }
}