using backend.Models.Api;
using backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using backend.Services.Exceptions;
using backend.Services.Mappers;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    /// <summary>
    /// The interfaces sits inside the Service for better readability by scaling
    /// </summary>
    public interface IBucketService
    {
        Task<IEnumerable<ApiBucket>> GetBucketsAsync();
        Task<ApiBucket> GetBucketByIdAsync(Guid bucketId);
        Task<Guid> CreateBucketAsync(ApiBucketCreate apiBucketCreate);
        Task UpdateBucketAsync(Guid bucketId, ApiBucket apiBucket);
        Task DeleteBucketAsync(Guid bucketId);
    }
    
    
    public class BucketService(DataContextService dataContext) : IBucketService
    {
        public async Task<IEnumerable<ApiBucket>> GetBucketsAsync()
        {
            List<Bucket>? buckets = await dataContext.Buckets.ToListAsync();
            
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
        
        public async Task<ApiBucket> GetBucketByIdAsync(Guid id)
        {
            Bucket? bucket = await dataContext.Buckets.FindAsync(id);
            
            if (bucket == null)
                throw new ItemNotFoundException(id); // Returns HTTP 404, if the element gets not found
            
            ApiBucket apiBucket = BucketMapper.ToDto(bucket);

            return apiBucket;
        }

        public async Task<Guid> CreateBucketAsync([FromBody] ApiBucketCreate apiBucketCreate)
        {
            if (apiBucketCreate == null)
                throw new ArgumentNullException(nameof(apiBucketCreate), "Bucket cannot be null.");
            
            Bucket bucket = BucketMapper.ToEntity(apiBucketCreate);

            dataContext.Buckets.Add(bucket);
            await dataContext.SaveChangesAsync();
            
            return bucket.Id;
        }

        public async Task UpdateBucketAsync(Guid id, [FromBody] ApiBucket apiBucket)
        {
            if (id != apiBucket.Id)
                throw new BadHttpRequestException("Bucket Id mismatch");
            
            Bucket? bucket = await dataContext.Buckets.FindAsync(id);
            
            if (bucket == null)
                throw new ItemNotFoundException(id);
            
            bucket = BucketMapper.ToEntity(apiBucket);
            
            dataContext.Buckets.Update(bucket);
            await dataContext.SaveChangesAsync();
        }

        public async Task DeleteBucketAsync(Guid id)
        {
            Bucket? bucket = await dataContext.Buckets.FindAsync(id);
            
            if (bucket == null)
                throw new ItemNotFoundException(id); 
            
            dataContext.Buckets.Remove(bucket);
            await dataContext.SaveChangesAsync();
        }
    }
}
