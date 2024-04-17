/**

Library class manages two types of lists: _books and _users, providing functionalities as follows: 
GetAllBooks() function to get all books with pagination and sorting and handling exceptions, 
GetAllUsers() function to get all users with pagination and sorting and handling exceptions, 
FindBookByTitle() function to search through the books list and find book by its title with case-insensitivity, 
FindUserByName() function to search through the users list and find user by their name with case-insensitivity, 
AddBook() function for adding new book to the library, AddUser() function for adding new user to the library, 
DeleteBookById() and DeleteUserById() functions for deleting books and users by id.
Also, INotificationService interface injected into the Library class to send notifications when book/user is added or deleted.
*/
public class Library
{
    private readonly List<Book> _books;
    private readonly List<User> _users;
    private readonly INotificationService _notificationService;

    public Library(INotificationService notificationService)
    {
        _books = new List<Book>();
        _users = new List<User>();
        _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
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
        try
        {
            _books.Add(book);

            if (_notificationService.GetType() == typeof(EmailNotificationService))
            {
                _notificationService.SendNotificationOnSuccess($"\na new book titled '{book.Title}' has been successfully added to the Library.\n");
            }
            else
            {
                _notificationService.SendNotificationOnSuccess($"Book '{book.Title}' added to Library.");
            }
        }
        catch (Exception e)
        {
            if (_notificationService.GetType() == typeof(EmailNotificationService))
            {
                _notificationService.SendNotificationOnFailure($"We encountered an issue adding '{book.Title}': \n{e.Message}.");
            }
            else
            {
                _notificationService.SendNotificationOnSuccess($"Error adding book '{book.Title}': \n{e.Message}.");
            }
        }
    }

    public void AddUser(User user)
    {
        try
        {
            _users.Add(user);

            if (_notificationService.GetType() == typeof(EmailNotificationService))
            {
                _notificationService.SendNotificationOnSuccess($"\na new user named '{user.Name}' has been successfully added to the Library.\n");
            }
            else
            {
                _notificationService.SendNotificationOnSuccess($"User '{user.Name}' added to Library.");
            }
        }
        catch (Exception e)
        {
            if (_notificationService.GetType() == typeof(EmailNotificationService))
            {
                _notificationService.SendNotificationOnFailure($"We encountered an issue adding '{user.Name}': \n{e.Message}.");
            }
            else
            {
                _notificationService.SendNotificationOnSuccess($"Error adding User '{user.Name}': \n{e.Message}.");
            }
        }
    }

    public void DeleteBookById(Guid id)
    {
        try
        {
            _books.RemoveAll(b => b.Id == id);

            if (_notificationService.GetType() == typeof(EmailNotificationService))
            {
                _notificationService.SendNotificationOnSuccess($"\nBook with the ID: '{id}' has been successfully deleted from the Library.\n");
            }
            else
            {
                _notificationService.SendNotificationOnSuccess($"Book with the ID: '{id}' deleted from Library.");
            }
        }
        catch (Exception e)
        {
            if (_notificationService.GetType() == typeof(EmailNotificationService))
            {
                _notificationService.SendNotificationOnFailure($"We encountered an issue deleting book with ID: '{id}'\n{e.Message}.");
            }
            else
            {
                _notificationService.SendNotificationOnSuccess($"Error deleting book with ID: '{id}'\n{e.Message}.");
            }
        }
    }

    public void DeleteUserById(Guid id)
    {
        try
        {
            _users.RemoveAll(u => u.Id == id);

            if (_notificationService.GetType() == typeof(EmailNotificationService))
            {
                _notificationService.SendNotificationOnSuccess($"\nUser with the ID: '{id}' has been successfully deleted from the Library.\n");
            }
            else
            {
                _notificationService.SendNotificationOnSuccess($"User with the ID: '{id}' deleted from Library.");
            }
        }
        catch (Exception e)
        {
            if (_notificationService.GetType() == typeof(EmailNotificationService))
            {
                _notificationService.SendNotificationOnFailure($"We encountered an issue deleting user with ID: '{id}'\n{e.Message}.");
            }
            else
            {
                _notificationService.SendNotificationOnSuccess($"Error deleting user with ID: '{id}'\n{e.Message}.");
            }
        }
    }
}