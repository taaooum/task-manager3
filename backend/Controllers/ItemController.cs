using backend.Models.Api;
using backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using backend.Services;
using System.Net.Sockets;

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
            ItemDto item = await _itemService.GetItemById(id); 
            return item;
        }

        // GET: api/TaskItems
        [HttpGet("GetItems")]
        [ProducesResponseType<ItemDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<ItemDto>> GetItemlist()
        {
            IEnumerable<ItemDto> items = await _itemService.GetAllItems();
            return items; 
        }

        // POST: api/TaskItem
        [HttpPost]
        [ProducesResponseType<Item>(StatusCodes.Status201Created, Type = typeof(Item))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Item>> CreateItem([FromBody] ItemDto itemDto)
        {
            Item item = await _itemService.CreateItem(itemDto);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        // DELETE: api/TaskItems/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            await _itemService.DeleteItem(id);
            return NoContent(); // Returns a HTTP 204, if delete was successful
        }
    }
}
