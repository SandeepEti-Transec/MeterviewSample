namespace MeterView.Identity.API.Domain.Roles.DomainEvents;

public sealed class RoleCreated : DomainEvent
{
    public Role Role { get; set; } 
}
            