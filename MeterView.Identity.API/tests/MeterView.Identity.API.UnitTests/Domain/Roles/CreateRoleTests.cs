namespace MeterView.Identity.API.UnitTests.Domain.Roles;

using MeterView.Identity.API.SharedTestHelpers.Fakes.Role;
using MeterView.Identity.API.Domain.Roles;
using MeterView.Identity.API.Domain.Roles.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.Identity.API.Exceptions.ValidationException;

public class CreateRoleTests
{
    private readonly Faker _faker;

    public CreateRoleTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_role()
    {
        // Arrange
        var roleToCreate = new FakeRoleForCreation().Generate();
        
        // Act
        var role = Role.Create(roleToCreate);

        // Assert
        role.Key.Should().Be(roleToCreate.Key);
        role.DisplayName.Should().Be(roleToCreate.DisplayName);
        role.Group.Should().Be(roleToCreate.Group);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var roleToCreate = new FakeRoleForCreation().Generate();
        
        // Act
        var role = Role.Create(roleToCreate);

        // Assert
        role.DomainEvents.Count.Should().Be(1);
        role.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(RoleCreated));
    }
}