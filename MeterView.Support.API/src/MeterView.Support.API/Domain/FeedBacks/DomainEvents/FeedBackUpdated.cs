namespace MeterView.Support.API.Domain.FeedBacks.DomainEvents;

public sealed class FeedBackUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            