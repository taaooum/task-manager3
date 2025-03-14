using backend.Data;
using backend.Models.Domain;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class BucketRepository(RepositoryDbContext dbContext) : IBucketRepository
    {
        public async Task<List<Bucket>?> GetAllBuckets()
        {
            return await dbContext.Buckets.ToListAsync();
        }

        public async Task<Bucket?> GetBucketById(Guid id)
        {
            return await dbContext.Buckets.FindAsync(id);
        }

        public async Task AddBucket(Bucket bucket)
        {
            dbContext.Buckets.Add(bucket);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateBucket(Bucket bucket)
        {
            dbContext.Buckets.Update(bucket);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteBucket(Guid id)
        {
            var bucket = await dbContext.Buckets.FindAsync(id);
            if (bucket != null)
            {
                dbContext.Remove(bucket);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
