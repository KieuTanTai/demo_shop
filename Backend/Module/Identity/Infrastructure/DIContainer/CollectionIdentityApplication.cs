

using Identity.Application;
using Identity.Interfaces;
using Identity.Interfaces.IApplication;
using Identity.Models;
using Identity.Models.Account;
using Identity.Utils;
using Microsoft.AspNetCore.Identity;

namespace Identity.Infrastructure.DIContainer
{
    public static class CollectionIdentityApplication
    {
        public static IServiceCollection AddIdentityApplicationCollection(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            #region CONFIG

            var accountRules = new AccountRulesModel();
            configuration.GetSection("AccountRules").Bind(accountRules);

            services.Configure<PasswordHasherOptions>(options => {
                options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3;
                options.IterationCount = configuration.GetValue<int>("PasswordHasherOptions:IterationCount");
            });
            
            #endregion
            
            services.AddSingleton(accountRules);
            services.AddSingleton<IPasswordHasher<AccountModel>, PasswordHasher<AccountModel>>();
            services.AddSingleton<IAccountHelper, AccountHelper>();
            services.AddSingleton<IRoleApplication, RoleApplication>();
            services.AddSingleton<IAccountApplication, AccountApplication>();
            
            return services;
        }
    }
}