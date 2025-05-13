namespace MeterView.Devices.API.Domain.Devices.DomainEvents;

public sealed class DeviceCreated : DomainEvent
{
    public Device Device { get; set; } 
}
            