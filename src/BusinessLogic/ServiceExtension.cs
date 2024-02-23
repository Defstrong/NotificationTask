using DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic;

public static class ServiceExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<INotificationEventService, NotificationEventService>();
        services.AddRepositories();
    }
}
