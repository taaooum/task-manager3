using backend.Models.Api;

namespace backend.Services.Interfaces
{
    public interface IBucketService
    {
        Task<IEnumerable<BucketDto>> GetAllBuckets();
        Task<BucketDto> GetBucketById(Guid BucketId);
        Task<BucketDto> CreateBucket(BucketDto bucketDto);
        Task UpdateBucket(Guid BucketId, BucketDto bucketDto);
        Task DeleteBucket(Guid BucketId);
    }
}
