var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBackendServices();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
