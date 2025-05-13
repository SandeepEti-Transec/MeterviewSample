namespace MeterView.TrendLines.API.Domain.TrendLines.DomainEvents;

public sealed class TrendLineCreated : DomainEvent
{
    public TrendLine TrendLine { get; set; } 
}
            