using backend.Models.Domain;
using backend.Models.Api;
using Microsoft.AspNetCore.Mvc;
using backend.Repositories;
using backend.Services.Exceptions;
using backend.Services.Interfaces;
using backend.Services.Mappers;

namespace backend.Services
{
    public class ItemService : IItemService
    {
        private readonly ItemRepository _itemRepo;

        public ItemService(ItemRepository itemRepository) => _itemRepo = itemRepository;

        public async Task<IEnumerable<ItemDto>> GetAllItems()
        {
            var items = await _itemRepo.GetAllItems();
            if (items == null)
            {
                throw new ItemNotFoundException(); // No items were found
            }

            // Convert Items to ItemDtos list
            List<ItemDto> itemDtos = new List<ItemDto>();
            foreach (var item in items)
            {
                var itemDto = ItemMapper.ToDto(item);

                itemDtos.Add(itemDto);
            }

            return itemDtos;
        }
        
        public async Task<ItemDto> GetItemById(Guid id)
        {
            var item = await _itemRepo.GetItemById(id);
            if (item == null)
            {
                throw new ItemNotFoundException(id); // Returns HTTP 404, if the element gets not found
            }

            var itemDto = ItemMapper.ToDto(item);

            return itemDto;
        }

        public async Task<Item> CreateItem([FromBody] ItemDto itemDto)
        {
            if (itemDto == null)
            {
                throw new ItemNotFoundException(); // Returns error in the ModelState
            }
            
            var item = ItemMapper.ToEntity(itemDto);

            await _itemRepo.AddItem(item);
            
            return item;
        }

        public async Task UpdateItem (Guid id, [FromBody] ItemDto itemDto)
        {
            var item = await _itemRepo.GetItemById(id);
            if (item == null)
            {
                throw new ItemNotFoundException(id);
            }

            item = ItemMapper.ToEntity(id, itemDto);

            await _itemRepo.UpdateItem(item);
        }
        
        public async Task DeleteItem(Guid id)
        {
            if (await _itemRepo.GetItemById(id) == null)
            {
                throw new ItemNotFoundException(id); 
            }
            await _itemRepo.DeleteItem(id);
        }
    }
}
