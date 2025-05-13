namespace MeterView.Identity.API.Domain.Organizations.DomainEvents;

public sealed class OrganizationUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            