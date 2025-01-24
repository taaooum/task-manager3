using backend.Logic;
using backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BucketController : ControllerBase
    {
        private readonly BucketService _bucketService;
        public BucketController(BucketService bucketService)
        {
            _bucketService = bucketService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Bucket), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Bucket>> GetBucket(int id)
        {
            var bucket = _bucketService.GetBucketById(id);
            if (bucket == null)
            {
                return NotFound();
            }
            return Ok(bucket);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Bucket>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Bucket>>> GetBuckets()
        {
            var buckets = _bucketService.GetAllBuckets();
            return Ok(buckets);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Bucket), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Bucket>> CreateBucket([FromBody] Bucket bucket)
        {
            _bucketService.AddBucket(bucket);
            return CreatedAtAction(nameof(GetBucket), new { id = bucket.Id }, bucket);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBucket(int id)
        {
            var bucket = _bucketService.GetBucketById(id);
            if (bucket == null)
            {
                return NotFound();
            }
            _bucketService.DeleteBucket(id);
            return NoContent();
        }
    }
}
