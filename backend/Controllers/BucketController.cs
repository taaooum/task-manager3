using backend.Models.Api;
using backend.Services;
using backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BucketController : ControllerBase
    {
        private readonly BucketService _bucketService;
        public BucketController(BucketService bucketService) => _bucketService = bucketService;

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BucketDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BucketDto>> GetBucket(Guid id)
        {
            BucketDto bucket = await _bucketService.GetBucketById(id);
            return Ok(bucket);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<BucketDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<BucketDto>>> GetBuckets()
        {
            IEnumerable<BucketDto> buckets = await _bucketService.GetAllBuckets();
            return Ok(buckets);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Bucket), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Bucket>> CreateBucket([FromBody] BucketDto bucketDto)
        {
            Bucket bucket = await _bucketService.CreateBucket(bucketDto);
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
