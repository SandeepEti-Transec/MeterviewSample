namespace MeterView.TrendLines.API.IntegrationTests.FeatureTests.TrendLines;

using MeterView.TrendLines.API.SharedTestHelpers.Fakes.TrendLine;
using MeterView.TrendLines.API.Domain.TrendLines.Dtos;
using MeterView.TrendLines.API.Domain.TrendLines.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateTrendLineCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_trendline_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var trendLine = new FakeTrendLineBuilder().Build();
        await testingServiceScope.InsertAsync(trendLine);
        var updatedTrendLineDto = new FakeTrendLineForUpdateDto().Generate();

        // Act
        var command = new UpdateTrendLine.Command(trendLine.Id, updatedTrendLineDto);
        await testingServiceScope.SendAsync(command);
        var updatedTrendLine = await testingServiceScope
            .ExecuteDbContextAsync(db => db.TrendLines
                .FirstOrDefaultAsync(t => t.Id == trendLine.Id));

        // Assert
        updatedTrendLine.Name.Should().Be(updatedTrendLineDto.Name);
    }
}