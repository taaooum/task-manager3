using backend.Data;
using backend.Models.Domain;
using Microsoft.EntityFrameworkCore;
using backend.Repositories.Interfaces;

namespace backend.Repositories
{
    public class BucketRepository : IBucketRepository
    {
        private readonly RepositoryDbContext _context;
        public BucketRepository(RepositoryDbContext dbContext) => _context = dbContext;

        public async Task<List<Bucket>?> GetAllBuckets()
        {
            return await _context.Buckets.ToListAsync();
        }

        public async Task<Bucket?> GetBucketById(Guid id)
        {
            return await _context.Buckets.FindAsync(id);
        }

        public async Task AddBucket(Bucket bucket)
        {
            _context.Buckets.Add(bucket);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBucket(Guid id, Bucket bucket)
        {
            _context.Buckets.Update(bucket);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBucket(Guid id)
        {
            var bucket = await _context.Buckets.FindAsync(id);
            if (bucket != null)
            {
                _context.Remove(bucket);
            }
            await _context.SaveChangesAsync();
        }
    }
}
