using WebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ItemRepository>();

var app = builder.Build();

app.MapGet("/api/items", (ItemRepository _repo) => _repo.GetItemsAsync());

app.MapGet("/api/items/{id:int}", async (ItemRepository _repo, int id) =>
{
    var item = await _repo.GetItemByIdAsync(id);
    return item is not null ? Results.Ok(item) : Results.NotFound();
});

app.MapPost("/api/items", async (ItemRepository _repo, PostItemRequest request) =>
{
    var item = new Item(request.Name, request.Description);
    await _repo.AddItemAsync(item);
    return Results.Created($"/api/things/{item.Id}", item);
});

app.Run();

public record PostItemRequest(string Name, string Description);