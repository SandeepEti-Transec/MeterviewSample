namespace MeterView.Devices.API.Domain.Devices.Dtos;

using Destructurama.Attributed;

public sealed record DeviceDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LocationTag { get; set; }
    public string Location { get; set; }
    public string Status { get; set; }
}
