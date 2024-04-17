public class SMSNotificationService : INotificationService
{
    public void SendNotificationOnSuccess(string message)
    {
        string SMSMessage = $"{message} \nThank you!";
        SendSMS(SMSMessage);
    }

    public void SendNotificationOnFailure(string errorMessage)
    {
        string SMSMessage = $"{errorMessage}. \nPlease contact support via email at support@library.com";
        SendSMS(SMSMessage);
    }

    private void SendSMS(string message)
    {
        Console.WriteLine($"\nSMS sent: \n{message}\n");
    }
}
