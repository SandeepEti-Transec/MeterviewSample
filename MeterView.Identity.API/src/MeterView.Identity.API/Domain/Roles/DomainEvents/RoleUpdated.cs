namespace MeterView.Identity.API.Domain.Roles.DomainEvents;

public sealed class RoleUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            