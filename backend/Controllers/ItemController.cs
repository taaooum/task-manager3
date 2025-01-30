using backend.Models.Api;
using backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using backend.Services;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ItemService _itemService;
        public ItemController(ItemService itemService) => _itemService = itemService;
        
        // GET: api/TaskItem
        [HttpGet("GetItem{id}")]
        [ProducesResponseType<Item>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ItemDto> GetItem(Guid id)
        {
            var item = await _itemService.GetItemById(id); 
            return item;
        }

        // GET: api/TaskItems
        [HttpGet("GetItems")]
        [ProducesResponseType<Item>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<ItemDto>> GetItemlist()
        {
            var items = await _itemService.GetAllItems();
            return items; 
        }

        // POST: api/TaskItem
        [HttpPost]
        [ProducesResponseType<Item>(StatusCodes.Status201Created, Type = typeof(Item))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ItemDto>> CreateItem([FromBody] ItemDto itemDto)
        {
            var item = await _itemService.CreateItem(itemDto);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        // DELETE: api/TaskItems/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ItemDto>> DeleteItem(Guid id)
        {
            await _itemService.DeleteItem(id);
            return NoContent(); // Returns a HTTP 204, if delete was successful
        }
    }
}
