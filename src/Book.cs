// Book class inheriting from BaseEntity
public class Book : BaseEntity
{
    public string Title { get; }

    public Book(string title, DateTime? createdDate = null) : base(title, createdDate)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
    }
}