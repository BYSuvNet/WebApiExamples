using WebAPI.Repositories;

namespace WebAPI.EndPoints;

public static class PostItem
{
    public record Request(string Name, string Description);
    public record Response(string Name, string Description, DateTime CreatedAt);

    public class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app) =>
            app.MapPost("api/items", Handler);

        public static async Task<IResult> Handler(Request request, ItemRepository _repo)
        {
            var item = new Item(request.Name, request.Description);
            await _repo.AddItemAsync(item);
            return Results.Created($"/api/items/{item.Id}", new Response(item.Name, item.Description, item.CreatedAt));
        }
    }
}