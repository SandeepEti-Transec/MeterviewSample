namespace MeterView.TrendLines.API.Domain.TrendLines.Models;

using Destructurama.Attributed;

public sealed record TrendLineForCreation
{
    public string Name { get; set; }
}
