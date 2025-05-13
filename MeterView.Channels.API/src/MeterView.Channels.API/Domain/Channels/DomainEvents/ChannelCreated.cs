namespace MeterView.Channels.API.Domain.Channels.DomainEvents;

public sealed class ChannelCreated : DomainEvent
{
    public Channel Channel { get; set; } 
}
            