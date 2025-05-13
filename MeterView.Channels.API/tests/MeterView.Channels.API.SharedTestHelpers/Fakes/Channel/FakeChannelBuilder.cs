namespace MeterView.Channels.API.SharedTestHelpers.Fakes.Channel;

using MeterView.Channels.API.Domain.Channels;
using MeterView.Channels.API.Domain.Channels.Models;

public class FakeChannelBuilder
{
    private ChannelForCreation _creationData = new FakeChannelForCreation().Generate();

    public FakeChannelBuilder WithModel(ChannelForCreation model)
    {
        _creationData = model;
        return this;
    }
    
    public FakeChannelBuilder WithName(string name)
    {
        _creationData.Name = name;
        return this;
    }
    
    public FakeChannelBuilder WithValue(string value)
    {
        _creationData.Value = value;
        return this;
    }
    
    public Channel Build()
    {
        var result = Channel.Create(_creationData);
        return result;
    }
}