namespace MeterView.Channels.API.Domain.Channels.Models;

using Destructurama.Attributed;

public sealed record ChannelForUpdate
{
    public string Name { get; set; }
    public string Value { get; set; }
}
