// User class inheriting from BaseEntity
public class User : BaseEntity
{
    public string Name { get; }

    public User(string name, DateTime? createdDate = null) : base(createdDate)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}