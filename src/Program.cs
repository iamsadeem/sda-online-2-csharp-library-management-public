internal class Program
{
    private static void Main()
    {
        // Create instances of NotificationService for email and SMS
        var emailService = new EmailNotificationService();
        var smsService = new SMSNotificationService();

        // Create library instances with different notification services
        var libraryWithEmail = new Library(emailService);
        var libraryWithSMS = new Library(smsService);

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

        // Adding users to the library with email
        libraryWithEmail.AddUser(user1);
        libraryWithEmail.AddUser(user2);
        libraryWithEmail.AddUser(user3);
        libraryWithEmail.AddUser(user4);
        libraryWithEmail.AddUser(user5);
        libraryWithEmail.AddUser(user6);
        libraryWithEmail.AddUser(user7);
        libraryWithEmail.AddUser(user8);
        libraryWithEmail.AddUser(user9);
        libraryWithEmail.AddUser(user10);

        // Adding books to the library with email
        libraryWithEmail.AddBook(book1);
        libraryWithEmail.AddBook(book2);
        libraryWithEmail.AddBook(book3);
        libraryWithEmail.AddBook(book4);
        libraryWithEmail.AddBook(book5);
        libraryWithEmail.AddBook(book6);
        libraryWithEmail.AddBook(book7);
        libraryWithEmail.AddBook(book8);
        libraryWithEmail.AddBook(book9);
        libraryWithEmail.AddBook(book10);
        libraryWithEmail.AddBook(book11);
        libraryWithEmail.AddBook(book12);
        libraryWithEmail.AddBook(book13);
        libraryWithEmail.AddBook(book14);
        libraryWithEmail.AddBook(book15);
        libraryWithEmail.AddBook(book16);
        libraryWithEmail.AddBook(book17);
        libraryWithEmail.AddBook(book18);
        libraryWithEmail.AddBook(book19);
        libraryWithEmail.AddBook(book20);

        // Get all users and books of library with email - pagination 
        var emailUsersPage1 = libraryWithEmail.GetAllUsers(1, 10);
        var emailBooksPage1 = libraryWithEmail.GetAllBooks(1, 10);
        var emailBooksPage2 = libraryWithEmail.GetAllBooks(2, 10);

        // Display users of library with email in a table, all 10 users in one page
        Console.WriteLine("\nUsers in library with email sorted from oldest creation date to newest:");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        Console.WriteLine("| ID                                   | Name                      | Created Date              |");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        foreach (var user in emailUsersPage1)
        {
            Console.WriteLine($"| {user.Id,-27} | {user.Name,-25} | {user.CreatedDate.ToShortDateString(),-25} |");
        }
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");

        // Display books in a table with two pages, 10 books per page
        Console.WriteLine("\nBooks in library with email sorted from oldest creation date to newest (1/2):");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        Console.WriteLine("| ID                                   | Title                     | Created Date              |");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        foreach (var book in emailBooksPage1)
        {
            Console.WriteLine($"| {book.Id,-27} | {book.Title,-25} | {book.CreatedDate.ToShortDateString(),-25} |");
        }
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        Console.WriteLine("\nBooks in library with email sorted from oldest creation date to newest (2/2):");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        Console.WriteLine("| ID                                   | Title                     | Created Date              |");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        foreach (var book in emailBooksPage2)
        {
            Console.WriteLine($"| {book.Id,-27} | {book.Title,-25} | {book.CreatedDate.ToShortDateString(),-25} |");
        }
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");

        // Search for user by their name, output is: "User with the name: (Alice) was found." This search is case-insensitive.
        IEnumerable<User> searchedUser = libraryWithEmail.FindUserByName("alice");
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
        IEnumerable<Book> searchedBook = libraryWithEmail.FindBookByTitle("1984");
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
        libraryWithEmail.DeleteUserById(user1.Id);

        // Delete book1 by id        
        Console.WriteLine($"\nDelete {book1.Title} by ID: ({book1.Id})");
        libraryWithEmail.DeleteBookById(book1.Id);

        // Adding users to the library with SMS
        libraryWithSMS.AddUser(user1);
        libraryWithSMS.AddUser(user2);
        libraryWithSMS.AddUser(user3);
        libraryWithSMS.AddUser(user4);
        libraryWithSMS.AddUser(user5);
        libraryWithSMS.AddUser(user6);
        libraryWithSMS.AddUser(user7);
        libraryWithSMS.AddUser(user8);
        libraryWithSMS.AddUser(user9);
        libraryWithSMS.AddUser(user10);

        // Adding books to the library with SMS
        libraryWithSMS.AddBook(book1);
        libraryWithSMS.AddBook(book2);
        libraryWithSMS.AddBook(book3);
        libraryWithSMS.AddBook(book4);
        libraryWithSMS.AddBook(book5);
        libraryWithSMS.AddBook(book6);
        libraryWithSMS.AddBook(book7);
        libraryWithSMS.AddBook(book8);
        libraryWithSMS.AddBook(book9);
        libraryWithSMS.AddBook(book10);
        libraryWithSMS.AddBook(book11);
        libraryWithSMS.AddBook(book12);
        libraryWithSMS.AddBook(book13);
        libraryWithSMS.AddBook(book14);
        libraryWithSMS.AddBook(book15);
        libraryWithSMS.AddBook(book16);
        libraryWithSMS.AddBook(book17);
        libraryWithSMS.AddBook(book18);
        libraryWithSMS.AddBook(book19);
        libraryWithSMS.AddBook(book20);

        // Get all users and books of library with SMS - pagination 
        var SMSUsersPage1 = libraryWithSMS.GetAllUsers(1, 10);
        var SMSBooksPage1 = libraryWithSMS.GetAllBooks(1, 10);
        var SMSBooksPage2 = libraryWithSMS.GetAllBooks(2, 10);

        // Display users of library with SMS in a table, all 10 users in one page
        Console.WriteLine("\nUsers in library with SMS sorted from oldest creation date to newest:");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        Console.WriteLine("| ID                                   | Name                      | Created Date              |");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        foreach (var user in SMSUsersPage1)
        {
            Console.WriteLine($"| {user.Id,-27} | {user.Name,-25} | {user.CreatedDate.ToShortDateString(),-25} |");
        }
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");

        // Display books in a table with two pages, 10 books per page
        Console.WriteLine("\nBooks in library with SMS sorted from oldest creation date to newest (1/2):");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        Console.WriteLine("| ID                                   | Title                     | Created Date              |");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        foreach (var book in SMSBooksPage1)
        {
            Console.WriteLine($"| {book.Id,-27} | {book.Title,-25} | {book.CreatedDate.ToShortDateString(),-25} |");
        }
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        Console.WriteLine("\nBooks in library with SMS sorted from oldest creation date to newest (2/2):");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        Console.WriteLine("| ID                                   | Title                     | Created Date              |");
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");
        foreach (var book in SMSBooksPage2)
        {
            Console.WriteLine($"| {book.Id,-27} | {book.Title,-25} | {book.CreatedDate.ToShortDateString(),-25} |");
        }
        Console.WriteLine("+----------------------------------------------------------------------------------------------+");

        // Search for user by their name, output is: "User with the name: (Alice) was found." This search is case-insensitive.
        IEnumerable<User> searchedUserInSMS = libraryWithSMS.FindUserByName("alice");
        if (searchedUserInSMS.Any())
        {
            foreach (var user in searchedUserInSMS)
            {
                Console.WriteLine($"\nUser with the name: ({user.Name}) was found.");
            }
        }
        else
        {
            Console.WriteLine("\nUser was not found.");
        }

        // Search for book by its title "1984", output is: "Book with the name: (1984) was found."
        IEnumerable<Book> searchedBookInSMS = libraryWithSMS.FindBookByTitle("1984");
        if (searchedBookInSMS.Any())
        {
            foreach (var book in searchedBookInSMS)
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
        libraryWithSMS.DeleteUserById(user1.Id);

        // Delete book1 by id        
        Console.WriteLine($"\nDelete {book1.Title} by ID: ({book1.Id})");
        libraryWithSMS.DeleteBookById(book1.Id);
    }
}