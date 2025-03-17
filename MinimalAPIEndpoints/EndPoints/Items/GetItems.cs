using Microsoft.AspNetCore.Mvc;
using WebAPI.Repositories;

namespace WebAPI.EndPoints;

public static class GetItems
{
    public record Response(IEnumerable<Item> Items);

    public class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app) =>
            app.MapGet("api/items", Handler);

        public static async Task<IResult> Handler([FromServices]ItemRepository _repo)
        {
            var items = await _repo.GetItemsAsync();
            return Results.Ok(new Response(items));
        }
    }
}