namespace MeterView.TrendLines.API.IntegrationTests.FeatureTests.TrendLines;

using MeterView.TrendLines.API.SharedTestHelpers.Fakes.TrendLine;
using MeterView.TrendLines.API.Domain.TrendLines.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class TrendLineQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_trendline_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var trendLineOne = new FakeTrendLineBuilder().Build();
        await testingServiceScope.InsertAsync(trendLineOne);

        // Act
        var query = new GetTrendLine.Query(trendLineOne.Id);
        var trendLine = await testingServiceScope.SendAsync(query);

        // Assert
        trendLine.Name.Should().Be(trendLineOne.Name);
    }

    [Fact]
    public async Task get_trendline_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetTrendLine.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}