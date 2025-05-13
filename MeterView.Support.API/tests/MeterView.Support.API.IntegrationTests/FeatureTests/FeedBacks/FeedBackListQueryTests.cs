namespace MeterView.Support.API.IntegrationTests.FeatureTests.FeedBacks;

using MeterView.Support.API.Domain.FeedBacks.Dtos;
using MeterView.Support.API.SharedTestHelpers.Fakes.FeedBack;
using MeterView.Support.API.Domain.FeedBacks.Features;
using Domain;
using System.Threading.Tasks;

public class FeedBackListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_feedback_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var feedBackOne = new FakeFeedBackBuilder().Build();
        var feedBackTwo = new FakeFeedBackBuilder().Build();
        var queryParameters = new FeedBackParametersDto();

        await testingServiceScope.InsertAsync(feedBackOne, feedBackTwo);

        // Act
        var query = new GetFeedBackList.Query(queryParameters);
        var feedBacks = await testingServiceScope.SendAsync(query);

        // Assert
        feedBacks.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}