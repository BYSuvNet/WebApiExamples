using WebAPI.Repositories;

namespace WebAPI.EndPoints;

public static class GetItemById
{
    public record Response(string Name, string Description);

    public class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app) =>
            app.MapGet("api/items{id:int}", Handler);

        public static async Task<IResult> Handler(ItemRepository _repo, int id)
        {
            var item = await _repo.GetItemByIdAsync(id);
            return item is not null ? Results.Ok(new Response(item.Name, item.Description)) : Results.NotFound();
        }
    }
}