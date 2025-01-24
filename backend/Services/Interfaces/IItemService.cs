using backend.Models.Api;

namespace backend.Services.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetAllAsync();
        Task<ItemDto> GetByIdAsync(Guid itemId);
        Task<ItemDto> CreateAsync();
        Task UpdateAsync();
        Task DeleteAsync();
    }
}
