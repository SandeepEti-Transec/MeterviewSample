namespace MeterView.TrendLines.API.IntegrationTests.FeatureTests.TrendLines;

using MeterView.TrendLines.API.Domain.TrendLines.Dtos;
using MeterView.TrendLines.API.SharedTestHelpers.Fakes.TrendLine;
using MeterView.TrendLines.API.Domain.TrendLines.Features;
using Domain;
using System.Threading.Tasks;

public class TrendLineListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_trendline_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var trendLineOne = new FakeTrendLineBuilder().Build();
        var trendLineTwo = new FakeTrendLineBuilder().Build();
        var queryParameters = new TrendLineParametersDto();

        await testingServiceScope.InsertAsync(trendLineOne, trendLineTwo);

        // Act
        var query = new GetTrendLineList.Query(queryParameters);
        var trendLines = await testingServiceScope.SendAsync(query);

        // Assert
        trendLines.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}