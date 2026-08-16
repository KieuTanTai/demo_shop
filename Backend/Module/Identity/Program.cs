using Identity.DBContext;
using Identity.Infrastructure.DIContainer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddIdentityCollection();
builder.Services.ConfigureDbContext<IdentityDbContext>(options =>
                options.EnableServiceProviderCaching()
                        .EnableThreadSafetyChecks()
                        .EnableDetailedErrors()
                        .EnableSensitiveDataLogging());
                            
builder.Services.AddDbContext<IdentityDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                        .LogTo(Console.WriteLine, LogLevel.Information));

// builder.Services.AddDbContext<IdentityDbContext>(options =>
//                 options.UseInMemoryDatabase("Demo").LogTo(Console.WriteLine, LogLevel.Information));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
Console.WriteLine(connectionString);

app.Run();
