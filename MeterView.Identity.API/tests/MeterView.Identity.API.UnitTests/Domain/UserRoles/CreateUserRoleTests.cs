namespace MeterView.Identity.API.UnitTests.Domain.UserRoles;

using MeterView.Identity.API.SharedTestHelpers.Fakes.UserRole;
using MeterView.Identity.API.Domain.UserRoles;
using MeterView.Identity.API.Domain.UserRoles.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.Identity.API.Exceptions.ValidationException;

public class CreateUserRoleTests
{
    private readonly Faker _faker;

    public CreateUserRoleTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_userRole()
    {
        // Arrange
        var userRoleToCreate = new FakeUserRoleForCreation().Generate();
        
        // Act
        var userRole = UserRole.Create(userRoleToCreate);

        // Assert
        userRole.UserId.Should().Be(userRoleToCreate.UserId);
        userRole.RoleId.Should().Be(userRoleToCreate.RoleId);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var userRoleToCreate = new FakeUserRoleForCreation().Generate();
        
        // Act
        var userRole = UserRole.Create(userRoleToCreate);

        // Assert
        userRole.DomainEvents.Count.Should().Be(1);
        userRole.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(UserRoleCreated));
    }
}