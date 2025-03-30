using backend.Management;
using backend.Models.Api;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    /// <summary>
    /// Handles CRUD operations for items.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController(Management.Management service) : ControllerBase
    {
        /// <summary>
        /// Retrieves all available items.
        /// </summary>
        /// <returns>A list of all existing items.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ApiItem>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<List<ApiItem>> GetAllItems()
        {
            List<ApiItem> items = await service.GetItemsAsync();
            return items;
        }
        
        /// <summary>
        /// Retrieves an item by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the item.</param>
        /// <returns>The matching item.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiItem),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ApiItem> GetItem(Guid id)
        {
            ApiItem apiItem = await service.GetItemByIdAsync(id);
            return apiItem;
        }

        /// <summary>
        /// Creates a new item.
        /// </summary>
        /// <param name="apiItemCreate">The data for the item to be created.</param>
        /// <returns>The ID of the newly created item.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> CreateItem([FromBody] ApiItemCreate apiItemCreate)
        {
            Guid itemId = await service.CreateItemAsync(apiItemCreate);
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
            await service.UpdateItemAsync(id, apiItem);
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
            await service.DeleteItemAsync(id);
        }
    }
}