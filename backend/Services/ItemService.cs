using backend.Models.Domain;
using backend.Models.Api;
using Microsoft.AspNetCore.Mvc;
using backend.Repositories;
using backend.Services.Exceptions;
using backend.Services.Interfaces;

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
            // Convert Items to ItemDto list
            //var ownersDto = owners.Adapt<IEnumerable<OwnerDto>>();
            List<ItemDto> itemDtos = new List<ItemDto>();
            foreach (var item in items)
            {
                var itemDto = new ItemDto
                {
                    Id = item.Id,
                    Title = item.Title,
                    BucketId = item.BucketId,
                    Description = item.Description,
                    Reminder = item.Reminder,
                    DueDate = item.DueDate,
                    Frequency = item.Frequency,
                    IsComplete = item.IsComplete
                };
                
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
            //TODO: add Mapper Convert Item to ItemDto
            //var ownersDto = owners.Adapt<IEnumerable<OwnerDto>>();
            var itemDto = new ItemDto
            {
                Id = item.Id,
                Title = item.Title,
                BucketId = item.BucketId,
                Description = item.Description,
                Reminder = item.Reminder,
                DueDate = item.DueDate,
                Frequency = item.Frequency,
                IsComplete = item.IsComplete
            };

            return itemDto;
        }

        public async Task<ItemDto> CreateItem([FromBody] ItemDto itemDto)
        {
            if (itemDto == null)
            {
                throw new ItemNotFoundException(); // Returns error in the ModelState
            }
            
            //TODO: add Mapper
            var item = new Item{
                Title = itemDto.Title,
                BucketId = itemDto.BucketId,
                Description = itemDto.Description,
                Reminder = itemDto.Reminder,
                DueDate = itemDto.DueDate,
                Frequency = itemDto.Frequency,
                IsComplete = itemDto.IsComplete
            };
            
            await _itemRepo.AddItem(item);
            
            return itemDto;
        }

        public async Task UpdateItem (Guid id, [FromBody] ItemDto itemDto)
        {
            var item = await _itemRepo.GetItemById(id);
            if (item == null)
            {
                throw new ItemNotFoundException(id);
            }
            // TODO: replace with Mapper
            item = new Item{
                Title = itemDto.Title,
                BucketId = itemDto.BucketId,
                Description = itemDto.Description,
                Reminder = itemDto.Reminder,
                DueDate = itemDto.DueDate,
                Frequency = itemDto.Frequency,
                IsComplete = itemDto.IsComplete
            };
            
            await _itemRepo.UpdateItem(id, item);
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
