namespace MeterView.Channels.API.Domain.Channels.Dtos;

using Destructurama.Attributed;

public sealed record ChannelForCreationDto
{
    public string Name { get; set; }
    public string Value { get; set; }
}
