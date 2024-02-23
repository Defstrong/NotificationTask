namespace DataAccess;

public interface IMessageRepository
{
    Task SendAsync(DbNotificationEvent notificationEvent, CancellationToken cancellationToken = default);
}
