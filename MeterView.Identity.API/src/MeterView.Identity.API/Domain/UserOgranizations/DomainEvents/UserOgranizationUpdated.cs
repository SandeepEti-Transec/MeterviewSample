namespace MeterView.Identity.API.Domain.UserOgranizations.DomainEvents;

public sealed class UserOgranizationUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            