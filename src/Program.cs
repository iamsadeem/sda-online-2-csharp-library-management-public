internal class Program
{
    private static void Main()
    {
        // Create a library instance
        Library library = new Library();

        // Create instances of User class
        var user1 = new User("Alice", new DateTime(2023, 1, 1));
        var user2 = new User("Bob", new DateTime(2023, 2, 1));
        var user3 = new User("Charlie", new DateTime(2023, 3, 1));
        var user4 = new User("David", new DateTime(2023, 4, 1));
        var user5 = new User("Eve", new DateTime(2024, 5, 1));
        var user6 = new User("Fiona", new DateTime(2024, 6, 1));
        var user7 = new User("George", new DateTime(2024, 7, 1));
        var user8 = new User("Hannah", new DateTime(2024, 8, 1));
        var user9 = new User("Ian");
        var user10 = new User("Julia");

        // Create instances of Book class
        var book1 = new Book("The Great Gatsby", new DateTime(2023, 1, 1));
        var book2 = new Book("1984", new DateTime(2023, 2, 1));
        var book3 = new Book("To Kill a Mockingbird", new DateTime(2023, 3, 1));
        var book4 = new Book("The Catcher in the Rye", new DateTime(2023, 4, 1));
        var book5 = new Book("Pride and Prejudice", new DateTime(2023, 5, 1));
        var book6 = new Book("Wuthering Heights", new DateTime(2023, 6, 1));
        var book7 = new Book("Jane Eyre", new DateTime(2023, 7, 1));
        var book8 = new Book("Brave New World", new DateTime(2023, 8, 1));
        var book9 = new Book("Moby-Dick", new DateTime(2023, 9, 1));
        var book10 = new Book("War and Peace", new DateTime(2023, 10, 1));
        var book11 = new Book("Hamlet", new DateTime(2023, 11, 1));
        var book12 = new Book("Great Expectations", new DateTime(2023, 12, 1));
        var book13 = new Book("Ulysses", new DateTime(2024, 1, 1));
        var book14 = new Book("The Odyssey", new DateTime(2024, 2, 1));
        var book15 = new Book("The Divine Comedy", new DateTime(2024, 3, 1));
        var book16 = new Book("Crime and Punishment", new DateTime(2024, 4, 1));
        var book17 = new Book("The Brothers Karamazov", new DateTime(2024, 5, 1));
        var book18 = new Book("Don Quixote", new DateTime(2024, 6, 1));
        var book19 = new Book("The Iliad");
        var book20 = new Book("Anna Karenina");

        // Adding users to the library
        library.AddUser(user1);
        library.AddUser(user2);
        library.AddUser(user3);
        library.AddUser(user4);
        library.AddUser(user5);
        library.AddUser(user6);
        library.AddUser(user7);
        library.AddUser(user8);
        library.AddUser(user9);
        library.AddUser(user10);

        // Adding books to the library
        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(book3);
        library.AddBook(book4);
        library.AddBook(book5);
        library.AddBook(book6);
        library.AddBook(book7);
        library.AddBook(book8);
        library.AddBook(book9);
        library.AddBook(book10);
        library.AddBook(book11);
        library.AddBook(book12);
        library.AddBook(book13);
        library.AddBook(book14);
        library.AddBook(book15);
        library.AddBook(book16);
        library.AddBook(book17);
        library.AddBook(book18);
        library.AddBook(book19);
        library.AddBook(book20);

        // Get all users and books with pagination
        var usersPage1 = library.GetAllUsers(1, 10);
        var booksPage1 = library.GetAllBooks(1, 10);
        var booksPage2 = library.GetAllBooks(2, 10);

        // Display users in a table, all 10 users in one page
        Console.WriteLine("\nUsers sorted from oldest creation date to newest:");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        Console.WriteLine("| ID                                   | Name                      | Created Date              |");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        foreach (var user in usersPage1)
        {
            Console.WriteLine($"| {user.Id,-27} | {user.Name,-25} | {user.CreatedDate.ToShortDateString(),-25} |");
        }
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");

        // Display books in a table with two pages, 10 books per page
        Console.WriteLine("\nBooks sorted from oldest creation date to newest (1/2):");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        Console.WriteLine("| ID                                   | Title                     | Created Date              |");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        foreach (var book in booksPage1)
        {
            Console.WriteLine($"| {book.Id,-27} | {book.Title,-25} | {book.CreatedDate.ToShortDateString(),-25} |");
        }
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        Console.WriteLine("\nBooks sorted from oldest creation date to newest (2/2):");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        Console.WriteLine("| ID                                   | Title                     | Created Date              |");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        foreach (var book in booksPage2)
        {
            Console.WriteLine($"| {book.Id,-27} | {book.Title,-25} | {book.CreatedDate.ToShortDateString(),-25} |");
        }
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");

        // Search for user by their name, output is: "User with the name: (Alice) was found." This search is case-insensitive.
        IEnumerable<User> searchedUser = library.FindUserByName("alice");
        if (searchedUser.Any())
        {
            foreach (var user in searchedUser)
            {
                Console.WriteLine($"\nUser with the name: ({user.Name}) was found.");
            }
        }
        else
        {
            Console.WriteLine("\nUser was not found.");
        }

        // Search for book by its title "1984", output is: "Book with the name: (1984) was found."
        IEnumerable<Book> searchedBook = library.FindBookByTitle("1984");
        if (searchedBook.Any())
        {
            foreach (var book in searchedBook)
            {
                Console.WriteLine($"Book with the name: ({book.Title}) was found.");
            }
        }
        else
        {
            Console.WriteLine("Book was not found.");
        }

        // Delete user1 by id 
        Console.WriteLine($"\nDelete {user1.Name} by ID: ({user1.Id})");
        library.DeleteUserById(user1.Id);
        Console.WriteLine("User deleted.");
        // Display users in a table, all 10 users in one page
        Console.WriteLine("\nUsers sorted from oldest creation date to newest - updated:");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        Console.WriteLine("| ID                                   | Name                      | Created Date              |");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        foreach (var user in usersPage1)
        {
            Console.WriteLine($"| {user.Id,-27} | {user.Name,-25} | {user.CreatedDate.ToShortDateString(),-25} |");
        }
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");

        // Delete book1 by id        
        Console.WriteLine($"\nDelete {book1.Title} by ID: ({book1.Id})");
        library.DeleteBookById(book1.Id);
        Console.WriteLine("Book deleted.");
        // Display books in a table with two pages, 10 books per page
        Console.WriteLine("\nBooks sorted from oldest creation date to newest (1/2) - updated:");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        Console.WriteLine("| ID                                   | Title                     | Created Date              |");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        foreach (var book in booksPage1)
        {
            Console.WriteLine($"| {book.Id,-27} | {book.Title,-25} | {book.CreatedDate.ToShortDateString(),-25} |");
        }
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        Console.WriteLine("\nBooks sorted from oldest creation date to newest (2/2) - updated:");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        Console.WriteLine("| ID                                   | Title                     | Created Date              |");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        foreach (var book in booksPage2)
        {
            Console.WriteLine($"| {book.Id,-27} | {book.Title,-25} | {book.CreatedDate.ToShortDateString(),-25} |");
        }
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
    }
}