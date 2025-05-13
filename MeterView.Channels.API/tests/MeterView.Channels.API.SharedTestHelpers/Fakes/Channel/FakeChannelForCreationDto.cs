namespace MeterView.Channels.API.SharedTestHelpers.Fakes.Channel;

using AutoBogus;
using MeterView.Channels.API.Domain.Channels;
using MeterView.Channels.API.Domain.Channels.Dtos;

public sealed class FakeChannelForCreationDto : AutoFaker<ChannelForCreationDto>
{
    public FakeChannelForCreationDto()
    {
    }
}