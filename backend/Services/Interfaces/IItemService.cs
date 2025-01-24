using backend.Models.Api;

namespace backend.Services.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetAllAsync();
        Task<ItemDto> GetByIdAsync(Guid ownerId);
        Task<ItemDto> CreateAsync();
        Task UpdateAsync();
        Task DeleteAsync();
        Task<int> SetItemBucketAsync(Guid taskId, Guid bucketId);
    }
}
