using WebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ItemRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();