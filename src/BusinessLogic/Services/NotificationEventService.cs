using DataAccess;
using System.Runtime.CompilerServices;

namespace BusinessLogic;

public sealed class NotificationEventService : INotificationEventService
{
    private readonly INotificationEventRepository _notificationEventRepository;

    public NotificationEventService(INotificationEventRepository notificationEventRepository)
      => _notificationEventRepository = notificationEventRepository;

    public async Task<bool> CreateAsync(NotificationEventDto notificationEvent,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(notificationEvent);
        bool createResult = await _notificationEventRepository.CreateAsync(notificationEvent.DtoToNotification());
        return createResult;
    }

    public async IAsyncEnumerable<NotificationEventDto> GetAsync([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await foreach (DbNotificationEvent notificationEvent in _notificationEventRepository.GetAsync(cancellationToken))
            yield return notificationEvent.DtoToNotification();
    }
}
