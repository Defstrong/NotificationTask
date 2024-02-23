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
          EventDate = dbNotificationEvent.EventDate,
          WebsiteUrl = dbNotificationEvent.WebsiteUrl
      };

    public static DbNotificationEvent DtoToNotification(this NotificationEventDto notificationEventDto)
      => new()
      {
          OrderType = notificationEventDto.OrderType,
          SessionId = notificationEventDto.SessionId,
          Card = notificationEventDto.Card,
          EventDate = notificationEventDto.EventDate,
          WebsiteUrl = notificationEventDto.WebsiteUrl
      };
}
