using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public sealed class NotifyDbContext : DbContext
{
    DbSet<DbNotificationEvent> NotificationEvents => Set<DbNotificationEvent>();

    private string ConnectionString { get; } = string.Empty;
    private string DbPath { get; } = "../Presentation/app.db";


    public NotifyDbContext()
    {
        ConnectionString = $"Data Source={DbPath}";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite(ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}

