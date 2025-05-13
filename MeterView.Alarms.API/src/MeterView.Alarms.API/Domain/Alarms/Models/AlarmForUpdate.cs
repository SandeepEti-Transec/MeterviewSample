namespace MeterView.Alarms.API.Domain.Alarms.Models;

using Destructurama.Attributed;

public sealed record AlarmForUpdate
{
    public string Name { get; set; }
    public string Status { get; set; }
}
