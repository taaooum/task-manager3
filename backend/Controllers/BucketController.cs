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
        [ProducesResponseType(typeof(BucketDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BucketDto>> GetBucket(Guid id)
        {
            BucketDto bucket = await bucketService.GetBucketById(id);
            return Ok(bucket);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<BucketDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<BucketDto>>> GetAllBuckets()
        {
            IEnumerable<BucketDto> buckets = await bucketService.GetAllBuckets();
            return Ok(buckets);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Bucket), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Bucket>> CreateBucket([FromBody] CreateBucket createBucket)
        {
            Bucket bucket = await bucketService.CreateBucket(createBucket);
            return CreatedAtAction(nameof(GetBucket), new { id = bucket.Id }, bucket);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Bucket), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Bucket>> UpdateBucket(Guid id, [FromBody] BucketDto bucketDto)
        {
            await bucketService.UpdateBucket(id, bucketDto);
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
