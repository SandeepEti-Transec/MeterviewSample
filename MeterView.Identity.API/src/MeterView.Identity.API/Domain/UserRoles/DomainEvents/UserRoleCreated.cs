namespace MeterView.Identity.API.Domain.UserRoles.DomainEvents;

public sealed class UserRoleCreated : DomainEvent
{
    public UserRole UserRole { get; set; } 
}
            