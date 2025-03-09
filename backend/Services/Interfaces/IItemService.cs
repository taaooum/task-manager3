using backend.Models.Api;
using backend.Models.Domain;

namespace backend.Services.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetAllItems();
        Task<ItemDto> GetItemById(Guid itemId);
        Task<Item> CreateItem(ItemDto item);
        Task UpdateItem(Guid itemId, ItemDto itemDto);
        Task DeleteItem(Guid itemId);
    }
}
