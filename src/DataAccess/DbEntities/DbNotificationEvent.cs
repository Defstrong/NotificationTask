namespace DataAccess;

public sealed record DbNotificationEvent
{
    public string OrderType { get; init; } = string.Empty;
    public string SessionId { get; init; } = string.Empty;
    public string Card { get; init; } = string.Empty;
    public DateTime EventDate { get; init; }
    public string WebsiteUrl { get; init; } = string.Empty;
    public bool IsSended { get; set; }
}
