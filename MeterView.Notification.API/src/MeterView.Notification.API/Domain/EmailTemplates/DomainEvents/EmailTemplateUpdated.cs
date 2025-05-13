namespace MeterView.Notification.API.Domain.EmailTemplates.DomainEvents;

public sealed class EmailTemplateUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            