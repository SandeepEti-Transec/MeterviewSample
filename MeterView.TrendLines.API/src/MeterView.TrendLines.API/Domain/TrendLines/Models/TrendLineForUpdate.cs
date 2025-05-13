namespace MeterView.TrendLines.API.Domain.TrendLines.Models;

using Destructurama.Attributed;

public sealed record TrendLineForUpdate
{
    public string Name { get; set; }
}
