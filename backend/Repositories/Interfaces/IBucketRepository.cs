using backend.Models.Domain;

namespace backend.Repositories.Interfaces
{
    public interface IBucketRepository
    {
        Task<List<Bucket>> GetAllBuckets();
        Task<Bucket?> GetBucketById(Guid id);
        void AddBucket(Bucket bucket);
        void UpdateBucket(Bucket bucket);
        void DeleteBucket(Guid id);
    }
}
