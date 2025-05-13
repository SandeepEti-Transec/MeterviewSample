namespace MeterView.Notification.API.Domain.EmailTemplates.DomainEvents;

public sealed class EmailTemplateCreated : DomainEvent
{
    public EmailTemplate EmailTemplate { get; set; } 
}
            