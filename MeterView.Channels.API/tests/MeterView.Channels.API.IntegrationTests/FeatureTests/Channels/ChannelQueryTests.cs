namespace MeterView.Channels.API.IntegrationTests.FeatureTests.Channels;

using MeterView.Channels.API.SharedTestHelpers.Fakes.Channel;
using MeterView.Channels.API.Domain.Channels.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class ChannelQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_channel_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var channelOne = new FakeChannelBuilder().Build();
        await testingServiceScope.InsertAsync(channelOne);

        // Act
        var query = new GetChannel.Query(channelOne.Id);
        var channel = await testingServiceScope.SendAsync(query);

        // Assert
        channel.Name.Should().Be(channelOne.Name);
        channel.Value.Should().Be(channelOne.Value);
    }

    [Fact]
    public async Task get_channel_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetChannel.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}