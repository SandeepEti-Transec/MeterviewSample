namespace MeterView.Channels.API.IntegrationTests.FeatureTests.Channels;

using MeterView.Channels.API.SharedTestHelpers.Fakes.Channel;
using MeterView.Channels.API.Domain.Channels.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteChannelCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_channel_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var channel = new FakeChannelBuilder().Build();
        await testingServiceScope.InsertAsync(channel);

        // Act
        var command = new DeleteChannel.Command(channel.Id);
        await testingServiceScope.SendAsync(command);
        var channelResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Channels
                .CountAsync(c => c.Id == channel.Id));

        // Assert
        channelResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_channel_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteChannel.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_channel_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var channel = new FakeChannelBuilder().Build();
        await testingServiceScope.InsertAsync(channel);

        // Act
        var command = new DeleteChannel.Command(channel.Id);
        await testingServiceScope.SendAsync(command);
        var deletedChannel = await testingServiceScope.ExecuteDbContextAsync(db => db.Channels
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == channel.Id));

        // Assert
        deletedChannel?.IsDeleted.Should().BeTrue();
    }
}