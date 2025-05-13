namespace MeterView.Channels.API.UnitTests.Domain.Channels;

using MeterView.Channels.API.SharedTestHelpers.Fakes.Channel;
using MeterView.Channels.API.Domain.Channels;
using MeterView.Channels.API.Domain.Channels.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.Channels.API.Exceptions.ValidationException;

public class UpdateChannelTests
{
    private readonly Faker _faker;

    public UpdateChannelTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_channel()
    {
        // Arrange
        var channel = new FakeChannelBuilder().Build();
        var updatedChannel = new FakeChannelForUpdate().Generate();
        
        // Act
        channel.Update(updatedChannel);

        // Assert
        channel.Name.Should().Be(updatedChannel.Name);
        channel.Value.Should().Be(updatedChannel.Value);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var channel = new FakeChannelBuilder().Build();
        var updatedChannel = new FakeChannelForUpdate().Generate();
        channel.DomainEvents.Clear();
        
        // Act
        channel.Update(updatedChannel);

        // Assert
        channel.DomainEvents.Count.Should().Be(1);
        channel.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(ChannelUpdated));
    }
}