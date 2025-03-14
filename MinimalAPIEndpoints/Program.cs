using WebAPI.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpoints(typeof(Program).Assembly);

var app = builder.Build();

app.MapEndpoints();

app.Run();