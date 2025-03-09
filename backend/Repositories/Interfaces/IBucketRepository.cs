using backend.Models.Domain;

namespace backend.Repositories.Interfaces
{
    public interface IBucketRepository
    {
        Task<List<Bucket>?> GetAllBuckets();
        Task<Bucket?> GetBucketById(Guid id);
        Task AddBucket(Bucket bucket);
        Task UpdateBucket(Bucket bucket);
        Task DeleteBucket(Guid id);
    }
}
