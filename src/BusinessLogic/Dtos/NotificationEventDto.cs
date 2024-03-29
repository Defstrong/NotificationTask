namespace BusinessLogic;

public sealed record NotificationEventDto
{
    public string OrderType { get; init; } = string.Empty;
    public string SessionId { get; init; } = string.Empty;
    public string Card { get; init; } = string.Empty;
    public string EventDate { get; init; } = string.Empty;
    public string WebsiteUrl { get; init; } = string.Empty;
    public bool IsSended { get; init; }
}
