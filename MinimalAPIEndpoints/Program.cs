using WebAPI.EndPoints;
using WebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpoints(typeof(Program).Assembly);
builder.Services.AddScoped<ItemRepository>();

var app = builder.Build();

app.MapEndpoints();

app.Run();