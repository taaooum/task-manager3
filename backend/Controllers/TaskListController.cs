using backend.Data;
using backend.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskListController(TaskManagerDbContext context) : ControllerBase
    {
        private readonly TaskManagerDbContext _context = context;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskList(long id)
        {
            var listItem = await _context.TaskLists.FindAsync(id);
            if (listItem == null)
            {
                return NotFound();
            }
            return Ok(listItem);
        }

        [HttpGet]
        public async Task<IActionResult> GetTaskLists()
        {
            var listItems = await _context.TaskLists.ToListAsync();
            if (listItems == null)
            {
                return NotFound();
            }
            return Ok(listItems);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskList(TaskList taskList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Returns a error in the ModelState
            }

            _context.TaskLists.Add(taskList);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaskList), new { id = taskList.Id }, taskList);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskList(long id)
        {
            var listItem = await _context.TaskLists.FindAsync(id);
            if (listItem == null)
            {
                return NotFound();
            }

            _context.TaskLists.Remove(listItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
