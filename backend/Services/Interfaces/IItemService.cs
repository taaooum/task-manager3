using backend.Models.Api;
using backend.Models.Domain;

namespace backend.Services.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetAllItems();
        Task<ItemDto> GetItemById(Guid itemId);
        Task<Item> CreateItem(CreateItem createItem);
        Task UpdateItem(Guid itemId, ItemDto itemDto);
        Task DeleteItem(Guid itemId);
    }
}
