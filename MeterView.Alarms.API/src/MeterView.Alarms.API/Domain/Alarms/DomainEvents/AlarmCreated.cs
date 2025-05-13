namespace MeterView.Alarms.API.Domain.Alarms.DomainEvents;

public sealed class AlarmCreated : DomainEvent
{
    public Alarm Alarm { get; set; } 
}
            