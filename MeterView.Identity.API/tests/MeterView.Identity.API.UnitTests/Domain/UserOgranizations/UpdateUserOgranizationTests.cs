namespace MeterView.Identity.API.UnitTests.Domain.UserOgranizations;

using MeterView.Identity.API.SharedTestHelpers.Fakes.UserOgranization;
using MeterView.Identity.API.Domain.UserOgranizations;
using MeterView.Identity.API.Domain.UserOgranizations.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.Identity.API.Exceptions.ValidationException;

public class UpdateUserOgranizationTests
{
    private readonly Faker _faker;

    public UpdateUserOgranizationTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_userOgranization()
    {
        // Arrange
        var userOgranization = new FakeUserOgranizationBuilder().Build();
        var updatedUserOgranization = new FakeUserOgranizationForUpdate().Generate();
        
        // Act
        userOgranization.Update(updatedUserOgranization);

        // Assert
        userOgranization.UserId.Should().Be(updatedUserOgranization.UserId);
        userOgranization.OrganizationId.Should().Be(updatedUserOgranization.OrganizationId);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var userOgranization = new FakeUserOgranizationBuilder().Build();
        var updatedUserOgranization = new FakeUserOgranizationForUpdate().Generate();
        userOgranization.DomainEvents.Clear();
        
        // Act
        userOgranization.Update(updatedUserOgranization);

        // Assert
        userOgranization.DomainEvents.Count.Should().Be(1);
        userOgranization.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(UserOgranizationUpdated));
    }
}