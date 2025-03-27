using backend.Models.Domain;
using backend.Models.Api;
using Microsoft.AspNetCore.Mvc;
using backend.Repositories;
using backend.Services.Exceptions;
using backend.Services.Interfaces;
using backend.Services.Mappers;

namespace backend.Services
{
    public class ItemService(ItemRepository itemRepository) : IItemService
    {
        public async Task<IEnumerable<ApiItem>> GetAllItems()
        {
            List<Item>? items = await itemRepository.GetAllItems();
            if (items == null)
            {
                throw new ItemNotFoundException(); // No items were found
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
        
        public async Task<ApiItem> GetItemById(Guid id)
        {
            Item? item = await itemRepository.GetItemById(id);
            if (item == null)
            {
                throw new ItemNotFoundException(id); // Returns HTTP 404, if the element gets not found
            }

            ApiItem apiItem = ItemMapper.ToDto(item);

            return apiItem;
        }

        public async Task<Item> CreateItem([FromBody] ApiItemCreate apiItemCreate)
        {
            if (apiItemCreate == null)
                throw new ArgumentNullException(nameof(apiItemCreate), "Item cannot be null.");

            Item item = ItemMapper.ToEntity(apiItemCreate);

            await itemRepository.AddItem(item);
            
            return item;
        }

        public async Task UpdateItem (Guid id, [FromBody] ApiItem apiItem)
        {
            if (id != apiItem.Id)
                throw new BadHttpRequestException("Bucket Id mismatch");

            Item? item = await itemRepository.GetItemById(id);
            if (item == null)
                throw new ItemNotFoundException(id);
            
            item = ItemMapper.ToEntity(apiItem);

            await itemRepository.UpdateItem(item);
        }
        
        public async Task DeleteItem(Guid id)
        {
            if (await itemRepository.GetItemById(id) == null)
                throw new ItemNotFoundException(id); 
            
            await itemRepository.DeleteItem(id);
        }
    }
}
