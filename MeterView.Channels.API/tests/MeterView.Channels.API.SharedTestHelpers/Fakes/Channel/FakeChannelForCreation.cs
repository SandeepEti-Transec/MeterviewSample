namespace MeterView.Channels.API.SharedTestHelpers.Fakes.Channel;

using AutoBogus;
using MeterView.Channels.API.Domain.Channels;
using MeterView.Channels.API.Domain.Channels.Models;

public sealed class FakeChannelForCreation : AutoFaker<ChannelForCreation>
{
    public FakeChannelForCreation()
    {
    }
}