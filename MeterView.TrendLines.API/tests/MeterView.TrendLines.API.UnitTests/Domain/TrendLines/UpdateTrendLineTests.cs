namespace MeterView.TrendLines.API.UnitTests.Domain.TrendLines;

using MeterView.TrendLines.API.SharedTestHelpers.Fakes.TrendLine;
using MeterView.TrendLines.API.Domain.TrendLines;
using MeterView.TrendLines.API.Domain.TrendLines.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.TrendLines.API.Exceptions.ValidationException;

public class UpdateTrendLineTests
{
    private readonly Faker _faker;

    public UpdateTrendLineTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_trendLine()
    {
        // Arrange
        var trendLine = new FakeTrendLineBuilder().Build();
        var updatedTrendLine = new FakeTrendLineForUpdate().Generate();
        
        // Act
        trendLine.Update(updatedTrendLine);

        // Assert
        trendLine.Name.Should().Be(updatedTrendLine.Name);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var trendLine = new FakeTrendLineBuilder().Build();
        var updatedTrendLine = new FakeTrendLineForUpdate().Generate();
        trendLine.DomainEvents.Clear();
        
        // Act
        trendLine.Update(updatedTrendLine);

        // Assert
        trendLine.DomainEvents.Count.Should().Be(1);
        trendLine.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(TrendLineUpdated));
    }
}