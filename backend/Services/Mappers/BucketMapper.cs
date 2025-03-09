using backend.Models.Api;
using backend.Models.Domain;

namespace backend.Services.Mappers
{
    public class BucketMapper
    {
        public static Bucket ToEntity(BucketDto dto)
        {
            return new Bucket
            {
                Title = dto.Title,
                Description = dto.Description
            };
        }

        public static BucketDto ToDto(Bucket bucket)
        {
            return new BucketDto
            {
                Title = bucket.Title,
                Description = bucket.Description
            };
        }
    }
}
