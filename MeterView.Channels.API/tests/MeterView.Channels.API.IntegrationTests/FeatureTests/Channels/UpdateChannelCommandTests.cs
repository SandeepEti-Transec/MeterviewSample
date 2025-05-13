namespace MeterView.Channels.API.IntegrationTests.FeatureTests.Channels;

using MeterView.Channels.API.SharedTestHelpers.Fakes.Channel;
using MeterView.Channels.API.Domain.Channels.Dtos;
using MeterView.Channels.API.Domain.Channels.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateChannelCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_channel_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var channel = new FakeChannelBuilder().Build();
        await testingServiceScope.InsertAsync(channel);
        var updatedChannelDto = new FakeChannelForUpdateDto().Generate();

        // Act
        var command = new UpdateChannel.Command(channel.Id, updatedChannelDto);
        await testingServiceScope.SendAsync(command);
        var updatedChannel = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Channels
                .FirstOrDefaultAsync(c => c.Id == channel.Id));

        // Assert
        updatedChannel.Name.Should().Be(updatedChannelDto.Name);
        updatedChannel.Value.Should().Be(updatedChannelDto.Value);
    }
}