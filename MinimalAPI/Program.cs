using WebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ItemRepository>();

var app = builder.Build();

app.MapGet("/api/items", async (ItemRepository _repo) =>
{
    var items = await _repo.GetItemsAsync();
    return Results.Ok(items.Select(item => new GetItemResponse(item.Name, item.Description, item.CreatedAt)));
});

app.MapGet("/api/items/{id:int}", async (ItemRepository _repo, int id) =>
{
    var item = await _repo.GetItemByIdAsync(id);
    return item is not null ? Results.Ok(new GetItemResponse(item.Name, item.Description, item.CreatedAt)) : Results.NotFound();
});

app.MapPost("/api/items", async (ItemRepository _repo, PostItemRequest request) =>
{
    var item = new Item(request.Name, request.Description);
    await _repo.AddItemAsync(item);
    return Results.Created($"/api/things/{item.Id}", new GetItemResponse(item.Name, item.Description, item.CreatedAt));
});

app.Run();

public record PostItemRequest(string Name, string Description);
public record GetItemResponse(string Name, string Description, DateTime CreatedAt);