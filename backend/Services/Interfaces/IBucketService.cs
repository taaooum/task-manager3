using backend.Models.Api;
using backend.Models.Domain;

namespace backend.Services.Interfaces
{
    public interface IBucketService
    {
        Task<IEnumerable<BucketDto>> GetAllBuckets();
        Task<BucketDto> GetBucketById(Guid bucketId);
        Task<Bucket> CreateBucket(CreateBucket createBucket);
        Task UpdateBucket(Guid bucketId, BucketDto bucketDto);
        Task DeleteBucket(Guid bucketId);
    }
}
