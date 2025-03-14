using backend.Data;
using backend.Models.Domain;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class ItemRepository(RepositoryDbContext dbContext) : IItemRepository
    {
        public async Task<List<Item>?> GetAllItems()
        {
            return await dbContext.Items.ToListAsync(); 
        }

        public async Task<Item?> GetItemById(Guid id)
        {
            return await dbContext.Items.FindAsync(id);
        }

        public async Task AddItem(Item item)
        {
            dbContext.Items.Add(item);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateItem(Item item) 
        {
            dbContext.Items.Update(item);
            await dbContext.SaveChangesAsync();
        }
        
        public async Task DeleteItem(Guid id)
        {
            var item = await dbContext.Items.FindAsync(id);
            if (item != null)
            {
                dbContext.Remove(item);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
