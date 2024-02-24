namespace DataAccess;

public interface INotificationEventRepository : IBaseDbRepository<DbNotificationEvent>
{
    IAsyncEnumerable<DbNotificationEvent> GetUnsendedAsync(CancellationToken cancellationToken);
}
