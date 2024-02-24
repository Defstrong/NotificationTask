using DataAccess;

namespace BusinessLogic;

public sealed class NotificationEventServiceFactory
{
    public static NotificationEventService GetNotificationEventService()
        => new(new NotificationEventRepository(new()));
}
