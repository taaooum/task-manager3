using backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Repositories;
using backend.Services.Exceptions;

namespace backend.Logic
{
    public class ItemService
    {
        private readonly ItemRepository _itemRepo;

        public ItemService(ItemRepository itemRepository) => _itemRepo = itemRepository;

        public async Task<Item> GetTaskItem(Guid id)
        {
            var taskItem = await _itemRepo.GetItemById(id);
            if (taskItem == null)
            {
                throw new ItemNotFoundException(id); // Returns a HTTP 404, if the element gets not found
            }
            return taskItem; // Returns element as JSON
        }

        public async Task<List<Item>> GetTaskItems()
        {
            var taskItems = await _context.TaskItems.ToListAsync();

            if (taskItems == null)
            {
                // TODO: eigene Exeption einbauen
                throw new Exception("keine Items gefunden!"); // Returns a HTTP 404, if the element gets not found
            }

            return taskItems; // Returns all elements in a list as JSON
        }

        public async Task<Item> CreateTaskItem([FromBody] Item taskItem)
        {
            if (false)
            {
                throw new Exception(); // Returns a error in the ModelState
            }

            _context.TaskItems.Add(taskItem);
            await _context.SaveChangesAsync();

            return taskItem;
        }

        public async Task<Item> DeleteTaskItem(long id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            
            if (taskItem == null)
            {
                throw new Exception(); // NotfoundException
            }

            _context.TaskItems.Remove(taskItem);
            await _context.SaveChangesAsync();

            return taskItem; // Returns a HTTP 204, if delete was successful
        }
    }
}
