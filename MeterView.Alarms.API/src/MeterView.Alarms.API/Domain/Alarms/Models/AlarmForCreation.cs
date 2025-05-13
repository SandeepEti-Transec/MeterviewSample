namespace MeterView.Alarms.API.Domain.Alarms.Models;

using Destructurama.Attributed;

public sealed record AlarmForCreation
{
    public string Name { get; set; }
    public string Status { get; set; }
}
