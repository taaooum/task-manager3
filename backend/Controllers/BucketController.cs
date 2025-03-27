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
        public async Task<ActionResult<ApiBucket>> GetBucket(Guid id)
        {
            ApiBucket apiBucket = await bucketService.GetBucketById(id);
            return Ok(apiBucket);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ApiBucket>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ApiBucket>>> GetAllBuckets()
        {
            IEnumerable<ApiBucket> buckets = await bucketService.GetAllBuckets();
            return Ok(buckets);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Bucket), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Bucket>> CreateBucket([FromBody] ApiBucketCreate apiBucketCreate)
        {
            Bucket bucket = await bucketService.CreateBucket(apiBucketCreate);
            return CreatedAtAction(nameof(GetBucket), new { id = bucket.Id }, bucket);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Bucket), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Bucket>> UpdateBucket(Guid id, [FromBody] ApiBucket apiBucket)
        {
            await bucketService.UpdateBucket(id, apiBucket);
            return NoContent();
        }
        
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBucket(Guid id)
        {
            await bucketService.DeleteBucket(id);
            return NoContent();
        }
    }
}
