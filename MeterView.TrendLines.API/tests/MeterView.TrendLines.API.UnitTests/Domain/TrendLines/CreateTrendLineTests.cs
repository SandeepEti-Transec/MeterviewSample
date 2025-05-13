namespace MeterView.TrendLines.API.UnitTests.Domain.TrendLines;

using MeterView.TrendLines.API.SharedTestHelpers.Fakes.TrendLine;
using MeterView.TrendLines.API.Domain.TrendLines;
using MeterView.TrendLines.API.Domain.TrendLines.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.TrendLines.API.Exceptions.ValidationException;

public class CreateTrendLineTests
{
    private readonly Faker _faker;

    public CreateTrendLineTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_trendLine()
    {
        // Arrange
        var trendLineToCreate = new FakeTrendLineForCreation().Generate();
        
        // Act
        var trendLine = TrendLine.Create(trendLineToCreate);

        // Assert
        trendLine.Name.Should().Be(trendLineToCreate.Name);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var trendLineToCreate = new FakeTrendLineForCreation().Generate();
        
        // Act
        var trendLine = TrendLine.Create(trendLineToCreate);

        // Assert
        trendLine.DomainEvents.Count.Should().Be(1);
        trendLine.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(TrendLineCreated));
    }
}