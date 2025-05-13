namespace MeterView.Identity.API.UnitTests.Domain.Roles;

using MeterView.Identity.API.SharedTestHelpers.Fakes.Role;
using MeterView.Identity.API.Domain.Roles;
using MeterView.Identity.API.Domain.Roles.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.Identity.API.Exceptions.ValidationException;

public class UpdateRoleTests
{
    private readonly Faker _faker;

    public UpdateRoleTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_role()
    {
        // Arrange
        var role = new FakeRoleBuilder().Build();
        var updatedRole = new FakeRoleForUpdate().Generate();
        
        // Act
        role.Update(updatedRole);

        // Assert
        role.Key.Should().Be(updatedRole.Key);
        role.DisplayName.Should().Be(updatedRole.DisplayName);
        role.Group.Should().Be(updatedRole.Group);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var role = new FakeRoleBuilder().Build();
        var updatedRole = new FakeRoleForUpdate().Generate();
        role.DomainEvents.Clear();
        
        // Act
        role.Update(updatedRole);

        // Assert
        role.DomainEvents.Count.Should().Be(1);
        role.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(RoleUpdated));
    }
}