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

    protected override async Task DoWorkAsync(CancellationToken cancellationToken = default)
    {
        List<DbNotificationEvent> unSendedNotificationEvents;
        lock (LockObject)
        {
            unSendedNotificationEvents = _notificationEventRepository
               .GetUnsendedAsync(cancellationToken).ToBlockingEnumerable().ToList();
        }

        if (!unSendedNotificationEvents.Any())
            return;

        for (int notifyIdx = 0; notifyIdx < unSendedNotificationEvents.Count(); notifyIdx++)
        {
            unSendedNotificationEvents[notifyIdx].IsSended = await _messageRepository
                .SendAsync(unSendedNotificationEvents[notifyIdx], cancellationToken);
        }

        lock (LockObject)
        {
            _notificationEventRepository.UpdateRangeAsync(unSendedNotificationEvents, cancellationToken);
        }
    }
}
