using backend.Models.Domain;
using backend.Services;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public interface IBucketRepository
    {
        Task<List<Bucket>?> GetAllBuckets();
        Task<Bucket?> GetBucketById(Guid id);
        Task AddBucket(Bucket bucket);
        Task UpdateBucket(Bucket bucket);
        Task DeleteBucket(Guid id);
    }
    
    public class BucketRepository(DataContextService dbContext) : IBucketRepository
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
