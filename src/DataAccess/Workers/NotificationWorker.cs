namespace DataAccess;

public sealed class NotificationWorker : BackgroundWorker
{
    private readonly IMessageRepository _messageRepository;
    private readonly INotificationEventRepository _notificationEventRepository;

    public NotificationWorker(IMessageRepository messageRepository, INotificationEventRepository notificationEventRepository)
    {
        _messageRepository = messageRepository;
        _notificationEventRepository = notificationEventRepository;
    }

    protected override async Task DoWorkAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<DbNotificationEvent> notificationEvents = _notificationEventRepository.GetAsync(cancellationToken).ToBlockingEnumerable();
        foreach (DbNotificationEvent notificationEvent in notificationEvents)
        {
            await _messageRepository.SendAsync(notificationEvent, cancellationToken);
        }
        await _notificationEventRepository.RemoveRange(notificationEvents);
    }
}
