namespace Module.Identity.Infrastructure.DIContainer;

public static class DIServiceCollectionAccount
{
    public static IServiceCollection AddIdentityCollection(this IServiceCollection services)
    {
        services.AddScoped<IAccountRepository, AccountRepository>();
        return services;
    }
}
