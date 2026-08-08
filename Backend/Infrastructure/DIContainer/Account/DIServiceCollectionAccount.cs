public static class DIServiceCollectionAccount
{
    public static IServiceCollection AddAccount(this IServiceCollection services)
    {
        services.AddSingleton<IAccountModelFactory, AccountModelFactory>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IAccountService, AccountService>();
        return services;
    }
}
