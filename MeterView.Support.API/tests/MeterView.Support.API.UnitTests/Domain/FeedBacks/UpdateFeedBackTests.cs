namespace MeterView.Support.API.UnitTests.Domain.FeedBacks;

using MeterView.Support.API.SharedTestHelpers.Fakes.FeedBack;
using MeterView.Support.API.Domain.FeedBacks;
using MeterView.Support.API.Domain.FeedBacks.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.Support.API.Exceptions.ValidationException;

public class UpdateFeedBackTests
{
    private readonly Faker _faker;

    public UpdateFeedBackTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_feedBack()
    {
        // Arrange
        var feedBack = new FakeFeedBackBuilder().Build();
        var updatedFeedBack = new FakeFeedBackForUpdate().Generate();
        
        // Act
        feedBack.Update(updatedFeedBack);

        // Assert
        feedBack.FullName.Should().Be(updatedFeedBack.FullName);
        feedBack.Title.Should().Be(updatedFeedBack.Title);
        feedBack.Email.Should().Be(updatedFeedBack.Email);
        feedBack.PhoneNumber.Should().Be(updatedFeedBack.PhoneNumber);
        feedBack.FeedBackOnMV.Should().Be(updatedFeedBack.FeedBackOnMV);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var feedBack = new FakeFeedBackBuilder().Build();
        var updatedFeedBack = new FakeFeedBackForUpdate().Generate();
        feedBack.DomainEvents.Clear();
        
        // Act
        feedBack.Update(updatedFeedBack);

        // Assert
        feedBack.DomainEvents.Count.Should().Be(1);
        feedBack.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(FeedBackUpdated));
    }
}