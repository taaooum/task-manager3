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
        public async Task<IEnumerable<ApiBucket>> GetAllBuckets()
        {
            List<Bucket>? buckets = await bucketRepository.GetAllBuckets();
            
            if (buckets == null)
                throw new BucketNotFoundException(); // No items were found
            
            
            List<ApiBucket> bucketDtoList = new List<ApiBucket>();
            foreach (Bucket bucket in buckets)
            {
                ApiBucket apiBucket = BucketMapper.ToDto(bucket);

                bucketDtoList.Add(apiBucket);
            }
            return bucketDtoList;
        }
        
        public async Task<ApiBucket> GetBucketById(Guid id)
        {
            Bucket? bucket = await bucketRepository.GetBucketById(id);
            
            if (bucket == null)
                throw new ItemNotFoundException(id); // Returns HTTP 404, if the element gets not found
            
            ApiBucket apiBucket = BucketMapper.ToDto(bucket);

            return apiBucket;
        }

        public async Task<Bucket> CreateBucket([FromBody] ApiBucketCreate apiBucketCreate)
        {
            if (apiBucketCreate == null)
                throw new ArgumentNullException(nameof(apiBucketCreate), "Bucket cannot be null.");
            
            Bucket bucket = BucketMapper.ToEntity(apiBucketCreate);

            await bucketRepository.AddBucket(bucket);
            
            return bucket;
        }

        public async Task UpdateBucket (Guid id, [FromBody] ApiBucket apiBucket)
        {
            if (id != apiBucket.Id)
                throw new BadHttpRequestException("Bucket Id mismatch");
            
            Bucket? bucket = await bucketRepository.GetBucketById(id);
            
            if (bucket == null)
                throw new ItemNotFoundException(id);
            
            bucket = BucketMapper.ToEntity(apiBucket);
            
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
