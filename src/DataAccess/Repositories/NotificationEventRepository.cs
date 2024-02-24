namespace DataAccess;

public sealed class NotificationEventRepository : BaseDbRepository<DbNotificationEvent>, INotificationEventRepository
{
    private readonly NotifyDbContext _context;

    public NotificationEventRepository(NotifyDbContext context) : base(context)
      => _context = context;
}
