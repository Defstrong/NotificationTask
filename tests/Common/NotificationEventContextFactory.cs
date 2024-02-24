using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Tests;

public class NotificationEventFactory
{
    public static NotifyDbContext Create()
    {
        var options = new DbContextOptionsBuilder<NotifyDbContext>()
          .UseInMemoryDatabase(Guid.NewGuid().ToString())
          .Options;

        var context = new NotifyDbContext();
        context.Database.EnsureCreated();
        return context;
    }

    public static void Destroy(NotifyDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}
