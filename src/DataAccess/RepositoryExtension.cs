using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class RepositoryExtension
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddDbContext<NotifyContext>();
        services.AddScoped<INotificationEventRepository, NotificationEventRepository>();
        services.AddScoped<NotificationWorker>();
        services.AddScoped<IMessageRepository, MessageRepository>();
    }
}
