using backend.Models.Api;
using backend.Models.Domain;

namespace backend.Services.Mappers
{
    public class ItemMapper
    {
        public static Item ToEntity(Guid id, ItemDto dto) // Convert a DTO to an entity with an ID for upadting
        {
            return new Item
            {
                Id = id,
                Title = dto.Title,
                Description = dto.Description,
                Reminder = dto.Reminder,
                BucketId = dto.BucketId,
                DueDate = dto.DueDate,
                Frequency = dto.Frequency,
                IsComplete = dto.IsComplete
            };
        }

        public static Item ToEntity(ItemDto dto)
        {
            return new Item
            {
                Title = dto.Title,
                Description = dto.Description,
                Reminder = dto.Reminder,
                BucketId = dto.BucketId,
                DueDate = dto.DueDate,
                Frequency = dto.Frequency,
                IsComplete = dto.IsComplete
            };
        }

        public static ItemDto ToDto(Item item)
        {
            return new ItemDto
            {
                Title = item.Title,
                Description = item.Description,
                Reminder = item.Reminder,
                BucketId = item.BucketId,
                DueDate = item.DueDate,
                Frequency = item.Frequency,
                IsComplete = item.IsComplete
            };
        }
    }
}
