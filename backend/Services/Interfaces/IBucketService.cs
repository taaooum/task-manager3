using backend.Models.Api;
using backend.Models.Domain;

namespace backend.Services.Interfaces
{
    public interface IBucketService
    {
        Task<IEnumerable<BucketDto>> GetAllBuckets();
        Task<BucketDto> GetBucketById(Guid BucketId);
        Task<Bucket> CreateBucket(BucketDto bucketDto);
        Task UpdateBucket(Guid BucketId, BucketDto bucketDto);
        Task DeleteBucket(Guid BucketId);
    }
}
