using backend.Data;
using backend.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Logic
{
    public class TaskItemLogic(TaskManagerDbContext context)
    {
        private readonly TaskManagerDbContext _context = context;

        public async Task<TaskItem> GetTaskItem(long id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
            {
                // TODO: eigene Exeption einbauen
                throw new Exception(); // Returns a HTTP 404, if the element gets not found
            }
            return taskItem; // Returns element as JSON
        }

        public async Task<List<TaskItem>> GetTaskItems()
        {
            var taskItems = await _context.TaskItems.ToListAsync();

            if (taskItems == null)
            {
                // TODO: eigene Exeption einbauen
                throw new Exception("keine Items gefunden!"); // Returns a HTTP 404, if the element gets not found
            }

            return taskItems; // Returns all elements in a list as JSON
        }

        public async Task<TaskItem> CreateTaskItem([FromBody] TaskItem taskItem)
        {
            if (true)
            {
                throw new Exception(); // Returns a error in the ModelState
            }

            _context.TaskItems.Add(taskItem);
            await _context.SaveChangesAsync();

            return taskItem;
        }

        public async Task<TaskItem> DeleteTaskItem(long id)
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
