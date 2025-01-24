using backend.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllItems();
        Task<Item?> GetItemById(Guid id);
        void AddItem(Item bucket);
        void UpdateItem(Item item);
        void DeleteItem(Guid id);
    }
}
