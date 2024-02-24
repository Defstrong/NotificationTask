using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
namespace DataAccess;

public sealed class NotificationEventRepository : BaseDbRepository<DbNotificationEvent>, INotificationEventRepository
{
    private readonly NotifyDbContext _context;

    public NotificationEventRepository(NotifyDbContext context) : base(context)
      => _context = context;

    public async IAsyncEnumerable<DbNotificationEvent> GetUnsendedAsync([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        List<DbNotificationEvent> unsendedNotificationEvents = await _context.Set<DbNotificationEvent>()
            .Where(notificationEvent => !notificationEvent.IsSended).AsNoTracking().ToListAsync();

        foreach (DbNotificationEvent notificationEvent in unsendedNotificationEvents)
            yield return notificationEvent;
    }
}
