public class EmailNotificationService : INotificationService
{
    public void SendNotificationOnSuccess(string message)
    {
        string emailMessage = $"Hello, {message}If you have any queries or feedback, please contact our support team at support@library.com.";
        SendEmail(emailMessage);
    }

    public void SendNotificationOnFailure(string errorMessage)
    {
        string emailMessage = $"{errorMessage}. Please review the input data. For more help, visit our FAQ at library.com/faq.";
        SendEmail(emailMessage);
    }

    private void SendEmail(string message)
    {
        Console.WriteLine($"\nEmail sent: \n{message}\n");
    }
}