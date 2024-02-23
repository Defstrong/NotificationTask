using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public sealed class NotifyContext : DbContext
{
    DbSet<DbNotificationEvent> NotificationEvents => Set<DbNotificationEvent>();

    private string ConnectionString { get; } = string.Empty;
    private string DbPath { get; } = "../Presentation/app.db";


    public NotifyContext() => ConnectionString = $"Data Source={DbPath}";

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite(ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}

