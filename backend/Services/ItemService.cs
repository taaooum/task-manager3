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
        public async Task<IEnumerable<ItemDto>> GetAllItems()
        {
            List<Item>? items = await itemRepository.GetAllItems();
            if (items == null)
            {
                throw new ItemNotFoundException(); // No items were found
            }

            // Convert Items to itemDtoList
            List<ItemDto> itemDtoList = new List<ItemDto>();
            foreach (Item item in items)
            {
                ItemDto itemDto = ItemMapper.ToDto(item);

                itemDtoList.Add(itemDto);
            }

            return itemDtoList;
        }
        
        public async Task<ItemDto> GetItemById(Guid id)
        {
            Item? item = await itemRepository.GetItemById(id);
            if (item == null)
            {
                throw new ItemNotFoundException(id); // Returns HTTP 404, if the element gets not found
            }

            ItemDto itemDto = ItemMapper.ToDto(item);

            return itemDto;
        }

        public async Task<Item> CreateItem([FromBody] CreateItem createItem)
        {
            if (createItem == null)
                throw new ArgumentNullException(nameof(createItem), "Item cannot be null.");

            Item item = ItemMapper.ToEntity(createItem);

            await itemRepository.AddItem(item);
            
            return item;
        }

        public async Task UpdateItem (Guid id, [FromBody] ItemDto itemDto)
        {
            if (id != itemDto.Id)
                throw new BadHttpRequestException("Bucket Id mismatch");

            Item? item = await itemRepository.GetItemById(id);
            if (item == null)
                throw new ItemNotFoundException(id);
            
            item = ItemMapper.ToEntity(itemDto);

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
