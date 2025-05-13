namespace MeterView.TrendLines.API.Domain.TrendLines.DomainEvents;

public sealed class TrendLineUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            