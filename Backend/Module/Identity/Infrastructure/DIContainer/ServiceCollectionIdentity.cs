using Identity.Infrastructure.Persistence.DBContext;
using Identity.Infrastructure.Repository;
using Identity.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;

namespace Identity.Infrastructure.DIContainer
{
    public static class ServiceCollectionAccount
    {
        public static IServiceCollection AddIdentityCollection(this IServiceCollection services,
            IConfiguration configuration, IHostEnvironment environment)
        {
            var connectionString = configuration.GetConnectionString("Identity")
                ?? throw new InvalidOperationException("Connection string 'Identity' was not found.");

            services.AddDbContext<IdentityDbContext>(options =>
            {
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

            services.AddScoped<IUnitOfWork, EfIdentityUnitOfWork>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            return services;
        }
    }
}