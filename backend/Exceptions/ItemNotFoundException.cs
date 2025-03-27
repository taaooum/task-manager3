namespace backend.Services.Exceptions
{
    public sealed class ItemNotFoundException : NotFoundException
    {
        public ItemNotFoundException()
            : base($"No items were found.")
        {
        }
        
        public ItemNotFoundException(Guid itemId)
            : base($"The item with the identifier {itemId} was not found.")
        {
        }
    }
}
