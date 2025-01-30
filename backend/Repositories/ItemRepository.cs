using backend.Data;
using backend.Models.Domain;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly RepositoryDbContext _context;
        public ItemRepository(RepositoryDbContext dbContext) => _context = dbContext;

        public async Task<List<Item>?> GetAllItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item?> GetItemById(Guid id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task AddItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItem(Guid id, Item item) //TODO: Id entfernen da item an Update übergeben wird
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
        }
        
        public async Task DeleteItem(Guid id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Remove(item);
            }
            await _context.SaveChangesAsync();
        }
    }
}
