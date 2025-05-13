namespace MeterView.DeviceAlert.API.Domain.DeviceAlerts.Models;

using Destructurama.Attributed;

public sealed record DeviceAlertForCreation
{
    public string Title { get; set; }
    public bool Isactive { get; set; }
}
