# Library Management System Assignment 📚

This assignment aims to implement a basic Library Management System as a C# console application, focusing on Object-Oriented Programming principles.

## Description

The system consists of books and users, where the library can contain different types of books (Comic, Novel, TextBook, ResearchPaper).

### Features

- **Basic Classes:**
  - Book: Properties include id, title, and created date.
  - User: Properties include id, name, and created date.
  - Library: Manages books and users.

- **Simple Inheritance:**
  - Base class for Book and User with common properties like id and created date.

- **Library Features:**
  - Get all books/users with pagination, sorted by created date.
  - Find books by title.
  - Find users by name.
  - Add new book/user to the library.
  - Delete book/user by id.

### Notification Service

- **INotificationService Interface:**
  - Methods: SendNotificationOnSuccess, SendNotificationOnFailure.

- **Notification Service Implementations:**
  - EmailNotificationService:
    - SendNotificationOnSuccess: Comprehensive email with action details.
    - SendNotificationOnFailure: Detailed error report with troubleshooting steps.
  - SMSNotificationService:
    - SendNotificationOnSuccess: Brief SMS confirming action.
    - SendNotificationOnFailure: Short error notice suggesting contacting support.

Happy coding! 🚀
