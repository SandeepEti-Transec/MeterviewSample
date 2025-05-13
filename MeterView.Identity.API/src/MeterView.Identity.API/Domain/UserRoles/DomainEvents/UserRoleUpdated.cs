namespace MeterView.Identity.API.Domain.UserRoles.DomainEvents;

public sealed class UserRoleUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            