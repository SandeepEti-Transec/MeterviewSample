namespace MeterView.TrendLines.API.IntegrationTests.FeatureTests.TrendLines;

using MeterView.TrendLines.API.SharedTestHelpers.Fakes.TrendLine;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MeterView.TrendLines.API.Domain.TrendLines.Features;

public class AddTrendLineCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_trendline_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var trendLineOne = new FakeTrendLineForCreationDto().Generate();

        // Act
        var command = new AddTrendLine.Command(trendLineOne);
        var trendLineReturned = await testingServiceScope.SendAsync(command);
        var trendLineCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.TrendLines
            .FirstOrDefaultAsync(t => t.Id == trendLineReturned.Id));

        // Assert
        trendLineReturned.Name.Should().Be(trendLineOne.Name);

        trendLineCreated.Name.Should().Be(trendLineOne.Name);
    }
}