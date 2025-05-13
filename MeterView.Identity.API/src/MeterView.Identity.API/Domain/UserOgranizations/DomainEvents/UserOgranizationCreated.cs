namespace MeterView.Identity.API.Domain.UserOgranizations.DomainEvents;

public sealed class UserOgranizationCreated : DomainEvent
{
    public UserOgranization UserOgranization { get; set; } 
}
            