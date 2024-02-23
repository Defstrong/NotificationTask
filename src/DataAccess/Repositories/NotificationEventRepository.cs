namespace DataAccess;

public sealed class NotificationEventRepository : BaseDbRepository<DbNotificationEvent>, INotificationEventRepository
{
    private readonly NotifyContext _context;

    public NotificationEventRepository(NotifyContext context) : base(context)
      => _context = context;
}
