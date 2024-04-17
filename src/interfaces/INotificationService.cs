public interface INotificationService
{
    void SendNotificationOnSuccess(string message);
    void SendNotificationOnFailure(string errorMessage);
}
