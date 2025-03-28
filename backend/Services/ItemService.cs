using backend.Models.Domain;
using backend.Models.Api;
using Microsoft.AspNetCore.Mvc;
using backend.Services.Exceptions;
using backend.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    /// <summary>
    /// The interfaces sits inside the Service for better readability by scaling
    /// </summary>
    public interface IItemService
    {
        Task<IEnumerable<ApiItem>> GetItemsAsync();
        Task<ApiItem> GetItemByIdAsync(Guid itemId);
        Task<Guid> CreateItemAsync(ApiItemCreate apiItemCreate);
        Task UpdateItemAsync(Guid itemId, ApiItem apiItem);
        Task DeleteItemAsync(Guid itemId);
    }
    
    /// <summary>
    /// 
    /// </summary>
    public class ItemService(DataContextService dataContext) : IItemService
    {
        public async Task<IEnumerable<ApiItem>> GetItemsAsync()
        {
            List<Item>? items = await dataContext.Items.ToListAsync();
            if (items == null)
            {
                throw new NotFoundException("No items were found.");
            }

            // Convert Items to itemDtoList
            List<ApiItem> itemDtoList = new List<ApiItem>();
            foreach (Item item in items)
            {
                ApiItem apiItem = ItemMapper.ToDto(item);

                itemDtoList.Add(apiItem);
            }

            return itemDtoList;
        }
        
        public async Task<ApiItem> GetItemByIdAsync(Guid id)
        {
            Item? item = await dataContext.Items.FindAsync(id);
            if (item == null)
            {
                throw new NotFoundException($"The item with the identifier {id} was not found."); // Returns HTTP 404, if the element gets not found
            }

            ApiItem apiItem = ItemMapper.ToDto(item);

            return apiItem;
        }

        public async Task<Guid> CreateItemAsync([FromBody] ApiItemCreate apiItemCreate)
        {
            if (apiItemCreate == null)
                throw new ArgumentNullException(nameof(apiItemCreate), "Item cannot be null.");

            Item item = ItemMapper.ToEntity(apiItemCreate);

            dataContext.Items.Add(item);
            await dataContext.SaveChangesAsync();
            
            return item.Id;
        }

        public async Task UpdateItemAsync(Guid id, [FromBody] ApiItem apiItem)
        {
            if (id != apiItem.Id)
                throw new BadRequestException("Bucket Id mismatch");

            Item? item = await dataContext.Items.FindAsync(id);
            if (item == null)
                throw new NotFoundException($"The item with the identifier {id} was not found.");
            
            item = ItemMapper.ToEntity(apiItem);

            dataContext.Items.Update(item);
            await dataContext.SaveChangesAsync();
        }
        
        public async Task DeleteItemAsync(Guid id)
        {
            Item? item = await dataContext.Items.FindAsync(id);
            if (item == null)
                throw new NotFoundException($"The item with the identifier {id} was not found.");

            dataContext.Remove(item);
            await dataContext.SaveChangesAsync();
        }
    }
}
