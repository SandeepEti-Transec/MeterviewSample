namespace MeterView.Alarms.API.Domain.Alarms.Dtos;

using Destructurama.Attributed;

public sealed record AlarmDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
}
