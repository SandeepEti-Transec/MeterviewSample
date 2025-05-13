namespace MeterView.Support.API.IntegrationTests.FeatureTests.FeedBacks;

using MeterView.Support.API.SharedTestHelpers.Fakes.FeedBack;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MeterView.Support.API.Domain.FeedBacks.Features;

public class AddFeedBackCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_feedback_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var feedBackOne = new FakeFeedBackForCreationDto().Generate();

        // Act
        var command = new AddFeedBack.Command(feedBackOne);
        var feedBackReturned = await testingServiceScope.SendAsync(command);
        var feedBackCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.FeedBacks
            .FirstOrDefaultAsync(f => f.Id == feedBackReturned.Id));

        // Assert
        feedBackReturned.FullName.Should().Be(feedBackOne.FullName);
        feedBackReturned.Title.Should().Be(feedBackOne.Title);
        feedBackReturned.Email.Should().Be(feedBackOne.Email);
        feedBackReturned.PhoneNumber.Should().Be(feedBackOne.PhoneNumber);
        feedBackReturned.FeedBackOnMV.Should().Be(feedBackOne.FeedBackOnMV);

        feedBackCreated.FullName.Should().Be(feedBackOne.FullName);
        feedBackCreated.Title.Should().Be(feedBackOne.Title);
        feedBackCreated.Email.Should().Be(feedBackOne.Email);
        feedBackCreated.PhoneNumber.Should().Be(feedBackOne.PhoneNumber);
        feedBackCreated.FeedBackOnMV.Should().Be(feedBackOne.FeedBackOnMV);
    }
}