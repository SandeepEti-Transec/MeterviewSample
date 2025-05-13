namespace MeterView.Channels.API.UnitTests.Domain.Channels;

using MeterView.Channels.API.SharedTestHelpers.Fakes.Channel;
using MeterView.Channels.API.Domain.Channels;
using MeterView.Channels.API.Domain.Channels.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.Channels.API.Exceptions.ValidationException;

public class CreateChannelTests
{
    private readonly Faker _faker;

    public CreateChannelTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_channel()
    {
        // Arrange
        var channelToCreate = new FakeChannelForCreation().Generate();
        
        // Act
        var channel = Channel.Create(channelToCreate);

        // Assert
        channel.Name.Should().Be(channelToCreate.Name);
        channel.Value.Should().Be(channelToCreate.Value);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var channelToCreate = new FakeChannelForCreation().Generate();
        
        // Act
        var channel = Channel.Create(channelToCreate);

        // Assert
        channel.DomainEvents.Count.Should().Be(1);
        channel.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(ChannelCreated));
    }
}