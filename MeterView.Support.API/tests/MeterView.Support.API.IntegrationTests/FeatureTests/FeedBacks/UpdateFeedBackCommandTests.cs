namespace MeterView.Support.API.IntegrationTests.FeatureTests.FeedBacks;

using MeterView.Support.API.SharedTestHelpers.Fakes.FeedBack;
using MeterView.Support.API.Domain.FeedBacks.Dtos;
using MeterView.Support.API.Domain.FeedBacks.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateFeedBackCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_feedback_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var feedBack = new FakeFeedBackBuilder().Build();
        await testingServiceScope.InsertAsync(feedBack);
        var updatedFeedBackDto = new FakeFeedBackForUpdateDto().Generate();

        // Act
        var command = new UpdateFeedBack.Command(feedBack.Id, updatedFeedBackDto);
        await testingServiceScope.SendAsync(command);
        var updatedFeedBack = await testingServiceScope
            .ExecuteDbContextAsync(db => db.FeedBacks
                .FirstOrDefaultAsync(f => f.Id == feedBack.Id));

        // Assert
        updatedFeedBack.FullName.Should().Be(updatedFeedBackDto.FullName);
        updatedFeedBack.Title.Should().Be(updatedFeedBackDto.Title);
        updatedFeedBack.Email.Should().Be(updatedFeedBackDto.Email);
        updatedFeedBack.PhoneNumber.Should().Be(updatedFeedBackDto.PhoneNumber);
        updatedFeedBack.FeedBackOnMV.Should().Be(updatedFeedBackDto.FeedBackOnMV);
    }
}