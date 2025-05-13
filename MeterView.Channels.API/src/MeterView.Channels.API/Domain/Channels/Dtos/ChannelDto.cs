namespace MeterView.Channels.API.Domain.Channels.Dtos;

using Destructurama.Attributed;

public sealed record ChannelDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
}
