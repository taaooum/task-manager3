using backend.Models.Api;
using backend.Models.Domain;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using backend.Repositories;
using backend.Services.Exceptions;
using backend.Services.Mappers;

namespace backend.Services
{
    public class BucketService(BucketRepository bucketRepository) : IBucketService
    {
        public async Task<IEnumerable<BucketDto>> GetAllBuckets()
        {
            List<Bucket>? buckets = await bucketRepository.GetAllBuckets();
            
            if (buckets == null)
                throw new BucketNotFoundException(); // No items were found
            
            
            List<BucketDto> bucketDtoList = new List<BucketDto>();
            foreach (Bucket bucket in buckets)
            {
                BucketDto bucketDto = BucketMapper.ToDto(bucket);

                bucketDtoList.Add(bucketDto);
            }
            return bucketDtoList;
        }
        
        public async Task<BucketDto> GetBucketById(Guid id)
        {
            Bucket? bucket = await bucketRepository.GetBucketById(id);
            
            if (bucket == null)
                throw new ItemNotFoundException(id); // Returns HTTP 404, if the element gets not found
            
            BucketDto bucketDto = BucketMapper.ToDto(bucket);

            return bucketDto;
        }

        public async Task<Bucket> CreateBucket([FromBody] CreateBucket createBucket)
        {
            if (createBucket == null)
                throw new ArgumentNullException(nameof(createBucket), "Bucket cannot be null.");
            
            Bucket bucket = BucketMapper.ToEntity(createBucket);

            await bucketRepository.AddBucket(bucket);
            
            return bucket;
        }

        public async Task UpdateBucket (Guid id, [FromBody] BucketDto bucketDto)
        {
            if (id != bucketDto.Id)
                throw new BadHttpRequestException("Bucket Id mismatch");
            
            Bucket? bucket = await bucketRepository.GetBucketById(id);
            
            if (bucket == null)
                throw new ItemNotFoundException(id);
            
            bucket = BucketMapper.ToEntity(bucketDto);
            
            await bucketRepository.UpdateBucket(bucket);
        }
        
        public async Task DeleteBucket(Guid id)
        {
            if (await bucketRepository.GetBucketById(id) == null)
                throw new ItemNotFoundException(id); 
            
            await bucketRepository.DeleteBucket(id);
        }
    }
}
