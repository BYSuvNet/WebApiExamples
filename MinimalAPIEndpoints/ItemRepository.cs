namespace WebAPI.Repositories;

public class ItemRepository
{
    private static List<Item> _items = [new Item("Cool Item", "An extremly cool item.", 1)];

    public async Task<Item?> GetItemByIdAsync(int id)
    {
        return await Task.FromResult(_items.FirstOrDefault(i => i.Id == id));
    }

    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
        return await Task.FromResult(_items);
    }

    public async Task AddItemAsync(Item item)
    {
        _items.Add(item);
        await Task.CompletedTask;
    }
}

public class Item(string name, string description, int? Id = null)
{
    public int Id { get; } = Id ?? new Random().Next(1, 100000); // Simulate ID generation
    public string Name { get; } = name;
    public string Description { get; } = description;
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
}