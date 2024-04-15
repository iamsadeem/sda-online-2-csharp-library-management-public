/**

Library class manages two types of lists: _books and _users, providing functionalities as follows: 
GetAllBooks() function to get all books with pagination and sorting and handling exceptions, 
GetAllUsers() function to get all users with pagination and sorting and handling exceptions, 
FindBookByTitle() function to search through the books list and find book by its title with case-insensitivity, 
FindUserByName() function to search through the users list and find user by their name with case-insensitivity, 
AddBook() function for adding new book to the library, AddUser() function for adding new user to the library, 
DeleteBookById() and DeleteUserById() functions for deleting books and users by id.
*/
public class Library
{
    private readonly List<Book> _books;
    private readonly List<User> _users;

    public Library()
    {
        _books = new List<Book>();
        _users = new List<User>();
    }

    public IEnumerable<Book> GetAllBooks(int page, int pageSize)
    {
        try
        {
            if (page <= 0 || pageSize <= 0)
            {
                throw new ArgumentException("Page and pageSize must be greater than zero.");
            }

            // Perform sorting, skipping, and taking operations
            return _books.OrderBy(b => b.CreatedDate)
                         .Skip((page - 1) * pageSize).Take(pageSize);
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while getting all books:\n{e.Message}");
            throw;
        }
    }

    public IEnumerable<User> GetAllUsers(int page, int pageSize)
    {
        try
        {
            if (page <= 0 || pageSize <= 0)
            {
                throw new ArgumentException("Page and pageSize must be greater than zero.");
            }

            // Perform sorting, skipping, and taking operations
            return _users.OrderBy(u => u.CreatedDate)
                         .Skip((page - 1) * pageSize).Take(pageSize);
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while getting all users:\n{e.Message}");
            throw;
        }
    }

    public IEnumerable<Book> FindBookByTitle(string title)
    {
        return _books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<User> FindUserByName(string name)
    {
        return _users.Where(u => u.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void DeleteBookById(Guid id)
    {
        _books.RemoveAll(b => b.Id == id);
    }

    public void DeleteUserById(Guid id)
    {
        _users.RemoveAll(u => u.Id == id);
    }
}