namespace MeterView.Alarms.API.Domain.Alarms.Dtos;

using Destructurama.Attributed;

public sealed record AlarmForUpdateDto
{
    public string Name { get; set; }
    public string Status { get; set; }
}
