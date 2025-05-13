namespace MeterView.Identity.API.UnitTests.Domain.UserOgranizations;

using MeterView.Identity.API.SharedTestHelpers.Fakes.UserOgranization;
using MeterView.Identity.API.Domain.UserOgranizations;
using MeterView.Identity.API.Domain.UserOgranizations.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.Identity.API.Exceptions.ValidationException;

public class CreateUserOgranizationTests
{
    private readonly Faker _faker;

    public CreateUserOgranizationTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_userOgranization()
    {
        // Arrange
        var userOgranizationToCreate = new FakeUserOgranizationForCreation().Generate();
        
        // Act
        var userOgranization = UserOgranization.Create(userOgranizationToCreate);

        // Assert
        userOgranization.UserId.Should().Be(userOgranizationToCreate.UserId);
        userOgranization.OrganizationId.Should().Be(userOgranizationToCreate.OrganizationId);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var userOgranizationToCreate = new FakeUserOgranizationForCreation().Generate();
        
        // Act
        var userOgranization = UserOgranization.Create(userOgranizationToCreate);

        // Assert
        userOgranization.DomainEvents.Count.Should().Be(1);
        userOgranization.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(UserOgranizationCreated));
    }
}