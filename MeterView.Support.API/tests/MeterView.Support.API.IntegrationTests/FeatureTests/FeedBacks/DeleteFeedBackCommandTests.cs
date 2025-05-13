namespace MeterView.Support.API.IntegrationTests.FeatureTests.FeedBacks;

using MeterView.Support.API.SharedTestHelpers.Fakes.FeedBack;
using MeterView.Support.API.Domain.FeedBacks.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteFeedBackCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_feedback_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var feedBack = new FakeFeedBackBuilder().Build();
        await testingServiceScope.InsertAsync(feedBack);

        // Act
        var command = new DeleteFeedBack.Command(feedBack.Id);
        await testingServiceScope.SendAsync(command);
        var feedBackResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.FeedBacks
                .CountAsync(f => f.Id == feedBack.Id));

        // Assert
        feedBackResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_feedback_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteFeedBack.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_feedback_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var feedBack = new FakeFeedBackBuilder().Build();
        await testingServiceScope.InsertAsync(feedBack);

        // Act
        var command = new DeleteFeedBack.Command(feedBack.Id);
        await testingServiceScope.SendAsync(command);
        var deletedFeedBack = await testingServiceScope.ExecuteDbContextAsync(db => db.FeedBacks
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == feedBack.Id));

        // Assert
        deletedFeedBack?.IsDeleted.Should().BeTrue();
    }
}