namespace MeterView.TrendLines.API.IntegrationTests.FeatureTests.TrendLines;

using MeterView.TrendLines.API.SharedTestHelpers.Fakes.TrendLine;
using MeterView.TrendLines.API.Domain.TrendLines.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteTrendLineCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_trendline_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var trendLine = new FakeTrendLineBuilder().Build();
        await testingServiceScope.InsertAsync(trendLine);

        // Act
        var command = new DeleteTrendLine.Command(trendLine.Id);
        await testingServiceScope.SendAsync(command);
        var trendLineResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.TrendLines
                .CountAsync(t => t.Id == trendLine.Id));

        // Assert
        trendLineResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_trendline_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteTrendLine.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_trendline_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var trendLine = new FakeTrendLineBuilder().Build();
        await testingServiceScope.InsertAsync(trendLine);

        // Act
        var command = new DeleteTrendLine.Command(trendLine.Id);
        await testingServiceScope.SendAsync(command);
        var deletedTrendLine = await testingServiceScope.ExecuteDbContextAsync(db => db.TrendLines
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == trendLine.Id));

        // Assert
        deletedTrendLine?.IsDeleted.Should().BeTrue();
    }
}