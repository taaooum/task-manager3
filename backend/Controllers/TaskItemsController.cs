using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TaskItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TaskItems
        [HttpGet]
        public async Task<IActionResult> GetTaskItems()
        {
            var taskItems = await _context.TaskItems.ToListAsync();
            return Ok(taskItems); // Returns all elements in a list as JSON
        }

        // GET: api/TaskItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskItem(long id)
        {
            var taskItem = await _context.TaskItems.FirstOrDefaultAsync(t => t.Id == id);
            if (taskItem == null)
            {
                return NotFound(); // Returns a HTTP 404, if the element gets not found
            }
            return Ok(taskItem); // Returns element as JSON
        }

        // POST: api/TaskItems
        [HttpPost]
        public async Task<IActionResult> CreateTaskItem([FromBody] TaskItem taskItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Returns a Error in the ModelState
            }

            _context.TaskItems.Add(taskItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaskItem), new { id = taskItem.Id }, taskItem);
        }

        // DELETE: api/TaskItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(long id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            _context.TaskItems.Remove(taskItem);
            await _context.SaveChangesAsync();

            return NoContent(); // Returns a HTTP 204, if delete was successful
        }
    }
}
