using backend.Models.Api;
using backend.Services;
using backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    /// <summary>
    /// Handles CRUD operations for buckets.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BucketController(BucketService bucketService) : ControllerBase
    {
        /// <summary>
        /// Retrieves a bucket by its ID.
        /// </summary>
        /// <param name="id">The unique identifier of the bucket.</param>
        /// <returns>The matching bucket.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiBucket), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiBucket>> GetBucket(Guid id)
        {
            ApiBucket apiBucket = await bucketService.GetBucketByIdAsync(id);
            return Ok(apiBucket);
        }

        /// <summary>
        /// Retrieves all available buckets.
        /// </summary>
        /// <returns>A list of all existing buckets.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ApiBucket>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ApiBucket>>> GetAllBuckets()
        {
            IEnumerable<ApiBucket> buckets = await bucketService.GetBucketsAsync();
            return Ok(buckets);
        }

        /// <summary>
        /// Creates a new bucket.
        /// </summary>
        /// <param name="apiBucketCreate">The data for the bucket to be created.</param>
        /// <returns>The ID of the newly created bucket.</returns>
        [HttpPost]
        [ProducesResponseType<Guid>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> CreateBucket([FromBody] ApiBucketCreate apiBucketCreate)
        {
            Guid bucketId = await bucketService.CreateBucketAsync(apiBucketCreate);
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
        public async Task UpdateBucket(Guid id, [FromBody] ApiBucket apiBucket)
        {
            await bucketService.UpdateBucketAsync(id, apiBucket);
        }
        
        /// <summary>
        /// Deletes a bucket by ID.
        /// </summary>
        /// <param name="id">The ID of the bucket to delete.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task DeleteBucket(Guid id)
        {
            await bucketService.DeleteBucketAsync(id);
        }
    }
}
