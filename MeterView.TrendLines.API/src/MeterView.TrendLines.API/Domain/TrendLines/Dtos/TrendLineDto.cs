namespace MeterView.TrendLines.API.Domain.TrendLines.Dtos;

using Destructurama.Attributed;

public sealed record TrendLineDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
