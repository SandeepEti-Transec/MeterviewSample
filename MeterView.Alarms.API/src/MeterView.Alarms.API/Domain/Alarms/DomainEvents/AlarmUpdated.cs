namespace MeterView.Alarms.API.Domain.Alarms.DomainEvents;

public sealed class AlarmUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            