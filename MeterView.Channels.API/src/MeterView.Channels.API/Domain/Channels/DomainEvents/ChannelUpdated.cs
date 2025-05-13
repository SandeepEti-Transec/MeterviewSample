namespace MeterView.Channels.API.Domain.Channels.DomainEvents;

public sealed class ChannelUpdated : DomainEvent
{
    public Guid Id { get; set; } 
}
            