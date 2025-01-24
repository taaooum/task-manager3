namespace backend.Models.Api
{
    public class BucketDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ItemDto> Items { get; set; }
    }
}
