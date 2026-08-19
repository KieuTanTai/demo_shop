using Identity.Infrastructure.DIContainer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityCollection(builder.Configuration, builder.Environment);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
