namespace DataAccess;

public interface IMessageRepository
{
    Task<bool> SendAsync(DbNotificationEvent notificationEvent, CancellationToken cancellationToken = default);
}
