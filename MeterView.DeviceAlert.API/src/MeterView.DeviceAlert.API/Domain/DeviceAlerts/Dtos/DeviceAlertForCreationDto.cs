namespace MeterView.DeviceAlert.API.Domain.DeviceAlerts.Dtos;

using Destructurama.Attributed;

public sealed record DeviceAlertForCreationDto
{
    public string Title { get; set; }
    public bool Isactive { get; set; }
}
