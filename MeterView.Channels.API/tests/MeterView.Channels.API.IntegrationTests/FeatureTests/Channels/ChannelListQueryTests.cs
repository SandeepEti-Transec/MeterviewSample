namespace MeterView.Channels.API.IntegrationTests.FeatureTests.Channels;

using MeterView.Channels.API.Domain.Channels.Dtos;
using MeterView.Channels.API.SharedTestHelpers.Fakes.Channel;
using MeterView.Channels.API.Domain.Channels.Features;
using Domain;
using System.Threading.Tasks;

public class ChannelListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_channel_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var channelOne = new FakeChannelBuilder().Build();
        var channelTwo = new FakeChannelBuilder().Build();
        var queryParameters = new ChannelParametersDto();

        await testingServiceScope.InsertAsync(channelOne, channelTwo);

        // Act
        var query = new GetChannelList.Query(queryParameters);
        var channels = await testingServiceScope.SendAsync(query);

        // Assert
        channels.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}