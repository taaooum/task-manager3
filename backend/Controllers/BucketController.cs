using backend.Models.Api;
using backend.Services;
using backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BucketController : ControllerBase
    {
        private readonly BucketService _bucketService;
        public BucketController(BucketService bucketService) => _bucketService = bucketService;

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Bucket), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Bucket>> GetBucket(Guid id)
        {
            var bucket = await _bucketService.GetBucketById(id);
            return Ok(bucket);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Bucket>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Bucket>>> GetBuckets()
        {
            var buckets = await _bucketService.GetAllBuckets();
            return Ok(buckets);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Bucket), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Bucket>> CreateBucket([FromBody] BucketDto bucketDto)
        {
            var bucket = await _bucketService.CreateBucket(bucketDto);
            return CreatedAtAction(nameof(GetBucket), new { id = bucket.Id }, bucket);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBucket(Guid id)
        {
            await _bucketService.DeleteBucket(id);
            return NoContent();
        }
    }
}
