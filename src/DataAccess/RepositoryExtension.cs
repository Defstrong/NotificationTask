using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class RepositoryExtension
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddDbContext<NotifyDbContext>();
        services.AddScoped<INotificationEventRepository, NotificationEventRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
    }
}
