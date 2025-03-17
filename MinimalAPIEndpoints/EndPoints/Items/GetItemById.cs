using Microsoft.AspNetCore.Mvc;
using WebAPI.Repositories;

namespace WebAPI.EndPoints;

public static class GetItemById
{
    public record Response(string Name, string Description, DateTime CreatedAt);

    public class Endpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app) =>
            app.MapGet("api/items/{id:int}", Handler);

        public static async Task<IResult> Handler
        (
            [FromServices] ItemRepository _repo, 
            [FromRoute] int id //FromRoute are captured values like {id:int} in the route
        )
        {
            var item = await _repo.GetItemByIdAsync(id);
            return item is not null 
                ? Results.Ok(new Response(item.Name, item.Description, item.CreatedAt)) 
                : Results.NotFound($"No item with id {id}");
        }
    }
}