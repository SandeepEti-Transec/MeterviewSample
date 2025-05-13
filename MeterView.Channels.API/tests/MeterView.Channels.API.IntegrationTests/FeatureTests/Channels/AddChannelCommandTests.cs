namespace MeterView.Channels.API.IntegrationTests.FeatureTests.Channels;

using MeterView.Channels.API.SharedTestHelpers.Fakes.Channel;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MeterView.Channels.API.Domain.Channels.Features;

public class AddChannelCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_channel_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var channelOne = new FakeChannelForCreationDto().Generate();

        // Act
        var command = new AddChannel.Command(channelOne);
        var channelReturned = await testingServiceScope.SendAsync(command);
        var channelCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Channels
            .FirstOrDefaultAsync(c => c.Id == channelReturned.Id));

        // Assert
        channelReturned.Name.Should().Be(channelOne.Name);
        channelReturned.Value.Should().Be(channelOne.Value);

        channelCreated.Name.Should().Be(channelOne.Name);
        channelCreated.Value.Should().Be(channelOne.Value);
    }
}