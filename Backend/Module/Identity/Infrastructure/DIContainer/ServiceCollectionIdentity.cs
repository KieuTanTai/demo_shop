using Identity.Infrastructure.Repository;
using Identity.Interfaces;

namespace Identity.Infrastructure.DIContainer
{
    public static class ServiceCollectionAccount
    {
        public static IServiceCollection AddIdentityCollection(this IServiceCollection services)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            return services;
        }
    }
}
