using backend.Management;
using backend.Models.Api;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    /// <summary>
    /// Handles CRUD operations for buckets.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BucketsController(Management.Management service) : ControllerBase
    {
        /// <summary>
        /// Retrieves all available buckets.
        /// </summary>
        /// <returns>A list of all existing buckets.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ApiBucket>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ApiBucket>>> GetBucketsAsync()
        {
            List<ApiBucket> buckets = await service.GetBucketsAsync();
            return Ok(buckets);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>A list of all existing buckets with a list of all their items.</returns>
        [HttpGet("items")]
        [ProducesResponseType(typeof(List<ApiBucket>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ApiBucketWithItems>>> GetBucketsWithItemsAsync()
        {
            List<ApiBucket> buckets = await service.GetBucketsAsync();

            List<ApiBucketWithItems> apiBucketsWithItemsList = new List<ApiBucketWithItems>();

            foreach (ApiBucket bucket in buckets)
            {
                List<ApiItem> items = await service.GetItemsByBucketIdAsync(bucket.Id);
        
                apiBucketsWithItemsList.Add(new ApiBucketWithItems
                {
                    Bucket = bucket,
                    Items = items
                });
            }
            return Ok(apiBucketsWithItemsList);
        }
        
        /// <summary>
        /// Retrieves a bucket by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the bucket.</param>
        /// <returns>The matching bucket.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiBucket), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiBucket>> GetBucketByIdAsync(Guid id)
        {
            ApiBucket apiBucket = await service.GetBucketByIdAsync(id);
            return Ok(apiBucket);
        }
        
        [HttpGet("{id}/items")]
        [ProducesResponseType(typeof(List<ApiItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ApiBucket>>> GetItemsByBucketIdAsync(Guid id)
        {
            List<ApiItem> apiItems = await service.GetItemsByBucketIdAsync(id);
            return Ok(apiItems);
        }
        
        /// <summary>
        /// Creates a new bucket.
        /// </summary>
        /// <param name="apiBucketCreate">The data for the bucket to be created.</param>
        /// <returns>The ID of the newly created bucket.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> CreateBucketAsync([FromBody] ApiBucketCreate apiBucketCreate)
        {
            Guid bucketId = await service.CreateBucketAsync(apiBucketCreate);
            return Created($"/api/buckets/{bucketId}", bucketId);
        }

        /// <summary>
        /// Updates an existing bucket.
        /// </summary>
        /// <param name="id">The ID of the bucket to update.</param>
        /// <param name="apiBucket">The updated bucket data.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task UpdateBucketAsync(Guid id, [FromBody] ApiBucket apiBucket)
        {
            await service.UpdateBucketAsync(id, apiBucket);
        }
        
        /// <summary>
        /// Deletes a bucket by ID.
        /// </summary>
        /// <param name="id">The ID of the bucket to delete.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task DeleteBucketAsync(Guid id)
        {
            await service.DeleteBucketAsync(id);
        }
    }
}
