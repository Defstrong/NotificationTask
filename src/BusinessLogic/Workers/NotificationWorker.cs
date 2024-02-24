using DataAccess;

namespace BusinessLogic;

public sealed class NotificationWorker : BackgroundWorker
{
    private readonly IMessageRepository _messageRepository;
    private readonly INotificationEventRepository _notificationEventRepository;
    private static readonly object LockObject = new object();

    public NotificationWorker(IMessageRepository messageRepository, INotificationEventRepository notificationEventRepository)
    {
        _messageRepository = messageRepository;
        _notificationEventRepository = notificationEventRepository;
    }

    protected override Task DoWorkAsync(CancellationToken cancellationToken = default)
    {
        lock (LockObject)
        {
            IEnumerable<DbNotificationEvent> notificationEvents = _notificationEventRepository
                .GetAsync(cancellationToken).ToBlockingEnumerable();

            if (!notificationEvents.Any())
                return Task.CompletedTask;

            foreach (DbNotificationEvent notificationEvent in notificationEvents)
            {
                _messageRepository.SendAsync(notificationEvent, cancellationToken);
            }

            _notificationEventRepository.RemoveRange(notificationEvents);
        }

        return Task.CompletedTask;
    }
}
