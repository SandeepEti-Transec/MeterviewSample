namespace MeterView.Support.API.Domain.FeedBacks.DomainEvents;

public sealed class FeedBackCreated : DomainEvent
{
    public FeedBack FeedBack { get; set; } 
}
            