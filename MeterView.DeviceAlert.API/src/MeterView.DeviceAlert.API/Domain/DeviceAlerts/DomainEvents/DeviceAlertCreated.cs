namespace MeterView.DeviceAlert.API.Domain.DeviceAlerts.DomainEvents;

public sealed class DeviceAlertCreated : DomainEvent
{
    public DeviceAlert DeviceAlert { get; set; } 
}
            