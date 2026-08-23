using Identity.Infrastructure.DIContainer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityRepositoryCollection(builder.Configuration, builder.Environment);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();