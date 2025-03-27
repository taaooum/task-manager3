using backend.Models.Api;
using backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using backend.Services;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController(ItemService itemService) : ControllerBase
    {
        // ROUTE - GET: api/TaskItem
        [HttpGet("GetItem{id}")]
        [ProducesResponseType<Item>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ApiItem> GetItem(Guid id)
        {
            ApiItem apiItem = await itemService.GetItemById(id); 
            return apiItem;
        }

        // ROUTE - GET: api/TaskItems
        [HttpGet("GetItems")]
        [ProducesResponseType<ApiItem>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<ApiItem>> GetAllItems()
        {
            IEnumerable<ApiItem> items = await itemService.GetAllItems();
            return items; 
        }

        // ROUTE - POST: api/TaskItem
        [HttpPost]
        [ProducesResponseType<Item>(StatusCodes.Status201Created, Type = typeof(Item))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Item>> CreateItem([FromBody] ApiItemCreate apiItemCreate)
        {
            Item item = await itemService.CreateItem(apiItemCreate);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        // ROUTE - DELETE: api/TaskItems/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            await itemService.DeleteItem(id);
            return NoContent(); // Returns an HTTP 204, if delete was successful
        }
    }
}
