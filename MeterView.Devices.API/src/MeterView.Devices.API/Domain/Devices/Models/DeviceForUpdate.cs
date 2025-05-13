namespace MeterView.Devices.API.Domain.Devices.Models;

using Destructurama.Attributed;

public sealed record DeviceForUpdate
{
    public string Name { get; set; }
    public string LocationTag { get; set; }
    public string Location { get; set; }
    public string Status { get; set; }
}
