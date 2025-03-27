using backend.Models.Api;
using backend.Models.Domain;

namespace backend.Services.Interfaces
{
    public interface IBucketService
    {
        Task<IEnumerable<ApiBucket>> GetAllBuckets();
        Task<ApiBucket> GetBucketById(Guid bucketId);
        Task<Bucket> CreateBucket(ApiBucketCreate apiBucketCreate);
        Task UpdateBucket(Guid bucketId, ApiBucket apiBucket);
        Task DeleteBucket(Guid bucketId);
    }
}
