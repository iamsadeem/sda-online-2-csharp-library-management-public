# Assignment: Library Management System

The goal of this assignment is to implement a basic Library Management System as a C# console application. This application will help you practice key principles in Object-Oriented Programming.

## Description

A library has books and users. Library can have different types of books (Comic, Novel, TextBook, ResearchPaper) as well.

Your job is to model this system using classes, interfaces, and/or abstract classes as you see fit.

## Level 1: Basic Library Setup
1. Create Basic Classes:
- Book with properties like id, title, created date.
- User with id, name, created date.
- Library to manage books and users.
2. Simple Inheritance:
- Based on the common features between User and Book, create a base class for them to inherit from.
- Id could be of type `Guid`, generated inside constructor. Date, if null, will be set to current date. Only title/name is required.
3. Library has features
- Get all books/users with pagination, sorted by created date.
- Find books by title
- Find users by name
- Add new book/user to the library
- Delete book/user by id
4. Use all the features above in `Program.cs`
  ```
  // Program.cs - You can also change these sample codes to adapt to your design
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
  ```
## Level 2: Setup Notification Service
1. Create an `INotificationService` interface with a method `SendNotificationOnSucess` and `SendNotificationOnFailure`.
2. Create two different notification service implementations: `EmailNotificationService` and `SMSNotificationService`.
   - EmailNotificationService implementation:
      - SendNotificationOnSuccess: Sends a comprehensive email, including action details, a summary of the item, user feedback instructions, and a support contact. For example, "Hello, a new book titled 'XYZ' has been successfully added to the Library. If you have any queries or feedback, please contact our support team at support@library.com."
      - SendNotificationOnFailure: Provides a detailed error report, troubleshooting steps, and a link to an FAQ or help page. E.g., "We encountered an issue adding 'ABC'. Please review the input data. For more help, visit our FAQ at library.com/faq." 
   - SMSNotificationService Implementation:
     - SendNotificationOnSuccess: Sends a brief SMS with action confirmation and a short status update. E.g., "Book 'XYZ' added to Library. Thank you!"
     - SendNotificationOnFailure: Provides a short error notice and a suggestion to contact support via a different channel. E.g., "Error adding User 'ABC'. Please email support@library.com." 
3. Inject INotificationService into the Library class. Send notifications on adding or deleting book/user.
4. We will have 2 libraries, using different implementation of notification service. Use all the features above in `Program.cs`
   ```
   class Program {
    static void Main()
      {
        var emailService = new EmailNotificationService();
        var smsService = new SMSNotificationService();

        var libraryWithEmail = new Library(emailService);
        var libraryWithSMS = new Library(smsService);

        // Demonstrate adding/removing books/users in each library and observe notifications
      }
   }
   ```

## Level 3: Use reflection 
- In `Library`, provide a method, using reflection, to print the name of actual notification services used by that instance. For example:
  ```
  class Program {
    static void Main()
      {
        var emailService = new EmailNotificationService();
        var smsService = new SMSNotificationService();

        var libraryWithEmail = new Library(emailService);
        var libraryWithSMS = new Library(smsService);

        libraryWithEmail.PrintNotificationServiceInfo() // Print: This Library instance uses the EmailNotificationService
        libraryWithSMS.PrintNotificationServiceInfo() // Print: This Library instance uses the SMSNotificationService

        // Demonstrate adding/removing books/users in each library and observe notifications
      }
  ```
