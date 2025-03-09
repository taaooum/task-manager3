using backend.Models.Api;
using backend.Models.Domain;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using backend.Repositories;
using backend.Services.Exceptions;
using backend.Services.Mappers;

namespace backend.Services
{
    public class BucketService : IBucketService
    {
        private readonly BucketRepository _bucketRepo;

        public BucketService(BucketRepository bucketRepository) => _bucketRepo = bucketRepository;

        public async Task<IEnumerable<BucketDto>> GetAllBuckets()
        {
            var buckets = await _bucketRepo.GetAllBuckets();
            if (buckets == null)
            {
                throw new BucketNotFoundException(); // No items were found
            }
            
            List<BucketDto> bucketDtos = new List<BucketDto>();
            foreach (var bucket in buckets)
            {
                var bucketDto = BucketMapper.ToDto(bucket);

                bucketDtos.Add(bucketDto);
            }
            return bucketDtos;
        }
        
        public async Task<BucketDto> GetBucketById(Guid id)
        {
            var bucket = await _bucketRepo.GetBucketById(id);
            if (bucket == null)
            {
                throw new ItemNotFoundException(id); // Returns HTTP 404, if the element gets not found
            }
            var bucketDto = BucketMapper.ToDto(bucket);

            return bucketDto;
        }

        public async Task<Bucket> CreateBucket([FromBody] BucketDto bucketDto)
        {
            var bucket = BucketMapper.ToEntity(bucketDto);

            await _bucketRepo.AddBucket(bucket);
            
            return bucket;
        }

        public async Task UpdateBucket (Guid id, [FromBody] BucketDto bucketDto)
        {
            var bucket = await _bucketRepo.GetBucketById(id);
            if (bucket == null)
            {
                throw new ItemNotFoundException(id);
            }

            bucket = BucketMapper.ToEntity(id, bucketDto);
            
            await _bucketRepo.UpdateBucket(bucket);
        }
        
        public async Task DeleteBucket(Guid id)
        {
            if (await _bucketRepo.GetBucketById(id) == null)
            {
                throw new ItemNotFoundException(id); 
            }
            await _bucketRepo.DeleteBucket(id);
        }
    }
}
