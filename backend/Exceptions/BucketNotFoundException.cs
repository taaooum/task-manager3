namespace backend.Services.Exceptions
{
    public sealed class BucketNotFoundException : NotFoundException
    {
        public BucketNotFoundException()
            : base($"No buckets were found.")
        {
        }
        
        public BucketNotFoundException(Guid listId)
            : base($"The list with the identifier {listId} was not found.")
        {
        }
    }
}
