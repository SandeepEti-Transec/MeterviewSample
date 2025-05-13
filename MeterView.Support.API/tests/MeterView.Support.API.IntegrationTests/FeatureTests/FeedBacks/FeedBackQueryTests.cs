namespace MeterView.Support.API.IntegrationTests.FeatureTests.FeedBacks;

using MeterView.Support.API.SharedTestHelpers.Fakes.FeedBack;
using MeterView.Support.API.Domain.FeedBacks.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class FeedBackQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_feedback_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var feedBackOne = new FakeFeedBackBuilder().Build();
        await testingServiceScope.InsertAsync(feedBackOne);

        // Act
        var query = new GetFeedBack.Query(feedBackOne.Id);
        var feedBack = await testingServiceScope.SendAsync(query);

        // Assert
        feedBack.FullName.Should().Be(feedBackOne.FullName);
        feedBack.Title.Should().Be(feedBackOne.Title);
        feedBack.Email.Should().Be(feedBackOne.Email);
        feedBack.PhoneNumber.Should().Be(feedBackOne.PhoneNumber);
        feedBack.FeedBackOnMV.Should().Be(feedBackOne.FeedBackOnMV);
    }

    [Fact]
    public async Task get_feedback_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetFeedBack.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}