namespace MeterView.Identity.API.Domain.Organizations.DomainEvents;

public sealed class OrganizationCreated : DomainEvent
{
    public Organization Organization { get; set; } 
}
            