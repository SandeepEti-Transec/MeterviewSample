namespace MeterView.Devices.API.Domain.Devices.DomainEvents;

public sealed class DeviceUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            