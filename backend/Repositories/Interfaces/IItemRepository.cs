using backend.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task<List<Item>?> GetAllItems();
        Task<Item?> GetItemById(Guid id);
        Task AddItem(Item bucket);
        Task UpdateItem(Guid id, Item item);
        Task DeleteItem(Guid id);
    }
}
