using DataAccess;
namespace BusinessLogic;

public static class NotificationEventExtensions
{
    public static NotificationEventDto DtoToNotification(this DbNotificationEvent dbNotificationEvent)
      => new()
      {
          OrderType = dbNotificationEvent.OrderType,
          SessionId = dbNotificationEvent.SessionId,
          Card = dbNotificationEvent.Card,
          EventDate = dbNotificationEvent.EventDate.ToString(),
          WebsiteUrl = dbNotificationEvent.WebsiteUrl,
          IsSended = dbNotificationEvent.IsSended
      };

    public static DbNotificationEvent DtoToNotification(this NotificationEventDto notificationEventDto)
      => new()
      {
          OrderType = notificationEventDto.OrderType,
          SessionId = notificationEventDto.SessionId,
          Card = notificationEventDto.Card,
          EventDate = DateTime.Parse(notificationEventDto.EventDate),
          WebsiteUrl = notificationEventDto.WebsiteUrl,
          IsSended = notificationEventDto.IsSended
      };
}
