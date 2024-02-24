using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess;

public sealed class NotifyConfituration : IEntityTypeConfiguration<DbNotificationEvent>
{
    public void Configure(EntityTypeBuilder<DbNotificationEvent> builder)
    {
        builder
          .ToTable("notify_event")
          .HasKey(notifyEvent => notifyEvent.SessionId);

        builder
          .Property(notifyEvent => notifyEvent.SessionId)
          .HasColumnType("VARCHAR")
          .HasColumnName("session_id")
          .IsRequired();

        builder
          .Property(notifyEvent => notifyEvent.OrderType)
          .HasColumnType("VARCHAR")
          .HasColumnName("order_type")
          .IsRequired();

        builder
          .Property(notifyEvent => notifyEvent.Card)
          .HasColumnType("VARCHAR")
          .HasColumnName("card")
          .IsRequired();

        builder
          .Property(notifyEvent => notifyEvent.EventDate)
          .HasColumnType("VARCHAR")
          .HasColumnName("event_date")
          .IsRequired();

        builder
          .Property(notifyEvent => notifyEvent.IsSended)
          .HasColumnType("BOOLEAN")
          .HasColumnName("is_sended")
          .IsRequired();

        builder
          .Property(notifyEvent => notifyEvent.WebsiteUrl)
          .HasColumnType("VARCHAR")
          .HasColumnName("website_url")
          .HasMaxLength(255)
          .IsRequired();
    }
}
