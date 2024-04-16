// Base class for entities with common properties
public class BaseEntity
{
    public Guid Id { get; }
    public DateTime CreatedDate { get; }

    public BaseEntity(DateTime? createdDate = null)
    {
        Id = Guid.NewGuid();
        CreatedDate = createdDate ?? DateTime.Now;
    }
}