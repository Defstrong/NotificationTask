namespace DataAccess;

public sealed class MessageRepository : IMessageRepository
{
    private readonly string _messageHelper = "{0}\n{1}\nCard {2}\nWebService {3}";

    public Task<bool> SendAsync(DbNotificationEvent notificationEvent, CancellationToken cancellationToken = default)
    {
        string message = CreateMessage(notificationEvent);
        Console.WriteLine(message);
        return Task.FromResult<bool>(true);
    }

    private string CreateMessage(DbNotificationEvent notificationEvent)
    {
        return string.Format(
            _messageHelper,
            notificationEvent.EventDate,
            notificationEvent.OrderType,
            notificationEvent.Card,
            notificationEvent.WebsiteUrl);
    }
}
