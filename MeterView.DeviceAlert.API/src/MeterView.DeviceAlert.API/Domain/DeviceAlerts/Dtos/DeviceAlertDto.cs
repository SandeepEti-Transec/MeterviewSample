namespace MeterView.DeviceAlert.API.Domain.DeviceAlerts.Dtos;

using Destructurama.Attributed;

public sealed record DeviceAlertDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool Isactive { get; set; }
}
