using backend.Data;
using backend.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class ItemRepository
    {
        private readonly RepositoryDbContext _context;
        public ItemRepository(RepositoryDbContext dbContext) => _context = dbContext;

        public async Task<List<Item>> GetAllBuckets()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item?> GetBucketById(Guid id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async void AddBucket(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
        }

        public async void DeleteBucket(Guid id)
        {
            var bucket = await _context.Items.FindAsync(id);
            if (bucket != null)
            {
                _context.Remove(bucket);
            }
        }
    }
}
