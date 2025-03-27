using backend.Models.Api;
using backend.Models.Domain;

namespace backend.Services.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<ApiItem>> GetAllItems();
        Task<ApiItem> GetItemById(Guid itemId);
        Task<Item> CreateItem(ApiItemCreate apiItemCreate);
        Task UpdateItem(Guid itemId, ApiItem apiItem);
        Task DeleteItem(Guid itemId);
    }
}
