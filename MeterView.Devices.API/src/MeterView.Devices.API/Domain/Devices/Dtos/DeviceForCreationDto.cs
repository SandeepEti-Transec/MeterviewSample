namespace MeterView.Devices.API.Domain.Devices.Dtos;

using Destructurama.Attributed;

public sealed record DeviceForCreationDto
{
    public string Name { get; set; }
    public string LocationTag { get; set; }
    public string Location { get; set; }
    public string Status { get; set; }
}
