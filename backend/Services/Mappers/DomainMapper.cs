using backend.Models.Domain;
using backend.Models.Api;

namespace backend.Services.Mapper
{
    public static class DomainMapper
    {
        public static Item ToDomain(this ItemDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new Item
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                
                //
            };
        }
    }
}

