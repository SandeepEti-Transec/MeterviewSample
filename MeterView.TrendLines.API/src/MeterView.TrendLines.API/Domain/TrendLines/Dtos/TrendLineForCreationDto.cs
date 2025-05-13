namespace MeterView.TrendLines.API.Domain.TrendLines.Dtos;

using Destructurama.Attributed;

public sealed record TrendLineForCreationDto
{
    public string Name { get; set; }
}
