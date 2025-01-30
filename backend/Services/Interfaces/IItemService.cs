using backend.Models.Api;

namespace backend.Services.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetAllItems();
        Task<ItemDto> GetItemById(Guid itemId);
        Task<ItemDto> CreateItem(ItemDto item);
        Task UpdateItem(Guid itemId, ItemDto itemDto);
        Task DeleteItem(Guid itemId);
    }
}
