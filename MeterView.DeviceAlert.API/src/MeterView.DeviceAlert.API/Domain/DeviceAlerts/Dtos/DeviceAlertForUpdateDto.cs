namespace MeterView.DeviceAlert.API.Domain.DeviceAlerts.Dtos;

using Destructurama.Attributed;

public sealed record DeviceAlertForUpdateDto
{
    public string Title { get; set; }
    public bool Isactive { get; set; }
}
