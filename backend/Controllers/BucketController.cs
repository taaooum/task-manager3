using backend.Models.Api;
using backend.Services;
using backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BucketController(BucketService bucketService) : ControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiBucket), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiBucket>> GetBucket(Guid id)
        {
            ApiBucket apiBucket = await bucketService.GetBucketByIdAsync(id);
            return Ok(apiBucket);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ApiBucket>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ApiBucket>>> GetAllBuckets()
        {
            IEnumerable<ApiBucket> buckets = await bucketService.GetBucketsAsync();
            return Ok(buckets);
        }

        [HttpPost]
        [ProducesResponseType<Guid>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Guid>> CreateBucket([FromBody] ApiBucketCreate apiBucketCreate)
        {
            Guid bucketId = await bucketService.CreateBucketAsync(apiBucketCreate);
            return Created($"/api/buckets/{bucketId}", bucketId);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task UpdateBucket(Guid id, [FromBody] ApiBucket apiBucket)
        {
            await bucketService.UpdateBucketAsync(id, apiBucket);
        }
        
        
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
