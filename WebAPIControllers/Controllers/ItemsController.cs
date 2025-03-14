using Microsoft.AspNetCore.Mvc;
using WebAPI.Repositories;

namespace WebAPIControllers.Controllers;

[ApiController]
[Route("/api/items")]
public class ItemsController : ControllerBase
{
    private readonly ItemRepository _repo;

    public ItemsController(ItemRepository itemsRepository)
    {
        _repo = itemsRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetItems()
    {
        var items = await _repo.GetItemsAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetItemById(int id)
    {
        var item = await _repo.GetItemByIdAsync(id);
        return item is not null ? Ok(item) : NotFound();

    }

    [HttpPost]
    public async Task<IActionResult> CreateItem(PostItemRequest request)
    {
        var item = new Item(request.Name, request.Description);
        await _repo.AddItemAsync(item);
        return Created($"/api/items/{item.Id}", item);
    }
}

public record PostItemRequest(string Name, string Description);
