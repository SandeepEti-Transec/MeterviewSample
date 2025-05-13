namespace MeterView.TrendLines.API.Domain.TrendLines.Dtos;

using Destructurama.Attributed;

public sealed record TrendLineForUpdateDto
{
    public string Name { get; set; }
}
