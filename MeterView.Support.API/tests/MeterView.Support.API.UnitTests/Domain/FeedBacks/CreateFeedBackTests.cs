namespace MeterView.Support.API.UnitTests.Domain.FeedBacks;

using MeterView.Support.API.SharedTestHelpers.Fakes.FeedBack;
using MeterView.Support.API.Domain.FeedBacks;
using MeterView.Support.API.Domain.FeedBacks.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.Support.API.Exceptions.ValidationException;

public class CreateFeedBackTests
{
    private readonly Faker _faker;

    public CreateFeedBackTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_feedBack()
    {
        // Arrange
        var feedBackToCreate = new FakeFeedBackForCreation().Generate();
        
        // Act
        var feedBack = FeedBack.Create(feedBackToCreate);

        // Assert
        feedBack.FullName.Should().Be(feedBackToCreate.FullName);
        feedBack.Title.Should().Be(feedBackToCreate.Title);
        feedBack.Email.Should().Be(feedBackToCreate.Email);
        feedBack.PhoneNumber.Should().Be(feedBackToCreate.PhoneNumber);
        feedBack.FeedBackOnMV.Should().Be(feedBackToCreate.FeedBackOnMV);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var feedBackToCreate = new FakeFeedBackForCreation().Generate();
        
        // Act
        var feedBack = FeedBack.Create(feedBackToCreate);

        // Assert
        feedBack.DomainEvents.Count.Should().Be(1);
        feedBack.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(FeedBackCreated));
    }
}