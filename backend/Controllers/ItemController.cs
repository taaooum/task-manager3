using backend.Data;
using backend.Logic;
using backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        public readonly ItemService _itemLogic; // to seperate Database operations from Api requests 

        // GET: api/TaskItem
        [HttpGet("GetItem{id}")]
        [ProducesResponseType<Item>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Item> GetItem(long id)
        {
            var taskItem = await _itemLogic.GetTaskItem(id); 
            
            return taskItem;
        }

        // GET: api/TaskItems
        [HttpGet("GetItems")]
        [ProducesResponseType<Item>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<List<Item>> GetItemlist()
        {
            var taskItems = await _itemLogic.GetTaskItems();

            return taskItems; // Returns all elements in a list as JSON
        }

        // POST: api/TaskItem
        [HttpPost]
        [ProducesResponseType<Item>(StatusCodes.Status201Created, Type = typeof(Item))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Item>> CreateItem([FromBody] Item item)
        {
            var newTask = await _itemLogic.CreateTaskItem(item);

            return CreatedAtAction(nameof(newTask), new { id = newTask.Id }, newTask);
        }

        // DELETE: api/TaskItems/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Item>> DeleteItem(long id)
        {
            var taskItem = await _itemLogic.DeleteTaskItem(id);

            return NoContent(); // Returns a HTTP 204, if delete was successful
        }
    }
}
