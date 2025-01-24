using backend.Models.Api;

namespace backend.Services.Interfaces
{
    public interface IBucketService
    {
        Task<IEnumerable<BucketDto>> GetAllAsync();
        Task<BucketDto> GetByIdAsync(Guid BucketId);
        Task<BucketDto> CreateAsync();
        Task UpdateAsync();
        Task DeleteAsync();
    }
}
