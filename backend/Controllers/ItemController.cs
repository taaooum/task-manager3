using backend.Models.Api;
using backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using backend.Services;

namespace backend.Controllers
{
    /// <summary>
    /// Handles CRUD operations for items.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController(ItemService itemService) : ControllerBase
    {
        /// <summary>
        /// Retrieves an item by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the item.</param>
        /// <returns>The matching item.</returns>
        [HttpGet("GetItem{id}")]
        [ProducesResponseType<ApiItem>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ApiItem> GetItem(Guid id)
        {
            ApiItem apiItem = await itemService.GetItemByIdAsync(id); 
            return apiItem;
        }

        /// <summary>
        /// Retrieves all available items.
        /// </summary>
        /// <returns>A list of all existing items.</returns>
        [HttpGet("GetItems")]
        [ProducesResponseType<ApiItem>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<ApiItem>> GetAllItems()
        {
            IEnumerable<ApiItem> items = await itemService.GetItemsAsync();
            return items; 
        }

        /// <summary>
        /// Creates a new item.
        /// </summary>
        /// <param name="apiItemCreate">The data for the item to be created.</param>
        /// <returns>The ID of the newly created item.</returns>
        [HttpPost]
        [ProducesResponseType<Guid>(StatusCodes.Status201Created, Type = typeof(Item))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> CreateItem([FromBody] ApiItemCreate apiItemCreate)
        {
            Guid itemId = await itemService.CreateItemAsync(apiItemCreate);
            return Created($"/api/buckets/{itemId}", itemId);
        }

        /// <summary>
        /// Updates an existing item.
        /// </summary>
        /// <param name="id">The ID of the item to update.</param>
        /// <param name="apiItem">The updated item data.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task UpdateBucket(Guid id, [FromBody] ApiItem apiItem)
        {
            await itemService.UpdateItemAsync(id, apiItem);
        }

        /// <summary>
        /// Deletes an item by ID.
        /// </summary>
        /// <param name="id">The ID of the item to delete.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task DeleteItem(Guid id)
        {
            await itemService.DeleteItemAsync(id);
        }
    }
}