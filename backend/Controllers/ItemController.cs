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
        [ProducesResponseType<ApiItem>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<ApiItem>> GetAllItems()
        {
            IEnumerable<ApiItem> items = await itemService.GetAllItems();
            return items; 
        }

        // ROUTE - POST: api/TaskItem
        [HttpPost]
        [ProducesResponseType<Guid>(StatusCodes.Status201Created, Type = typeof(Item))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> CreateItem([FromBody] ApiItemCreate apiItemCreate)
        {
            Item item = await itemService.CreateItem(apiItemCreate);
            return Created($"/api/buckets/{item.Id}", item.Id);
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task UpdateBucket(Guid id, [FromBody] ApiItem apiItem)
        {
            await itemService.UpdateItem(id, apiItem);
        }

        // ROUTE - DELETE: api/TaskItems/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task DeleteItem(Guid id)
        {
            await itemService.DeleteItem(id);
        }
    }
}
