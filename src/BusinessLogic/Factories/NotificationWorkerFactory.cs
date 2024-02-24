using DataAccess;

namespace BusinessLogic;

public sealed class NotificationWorkerFactory
{
    public static NotificationWorker GetNotificationWorker()
        => new(new MessageRepository(), new NotificationEventRepository(new()));
}
