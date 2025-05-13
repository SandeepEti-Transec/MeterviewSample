namespace MeterView.DeviceAlert.API.Domain.DeviceAlerts.DomainEvents;

public sealed class DeviceAlertUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            