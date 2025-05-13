namespace MeterView.Identity.API.UnitTests.Domain.UserRoles;

using MeterView.Identity.API.SharedTestHelpers.Fakes.UserRole;
using MeterView.Identity.API.Domain.UserRoles;
using MeterView.Identity.API.Domain.UserRoles.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.Identity.API.Exceptions.ValidationException;

public class UpdateUserRoleTests
{
    private readonly Faker _faker;

    public UpdateUserRoleTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_userRole()
    {
        // Arrange
        var userRole = new FakeUserRoleBuilder().Build();
        var updatedUserRole = new FakeUserRoleForUpdate().Generate();
        
        // Act
        userRole.Update(updatedUserRole);

        // Assert
        userRole.UserId.Should().Be(updatedUserRole.UserId);
        userRole.RoleId.Should().Be(updatedUserRole.RoleId);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var userRole = new FakeUserRoleBuilder().Build();
        var updatedUserRole = new FakeUserRoleForUpdate().Generate();
        userRole.DomainEvents.Clear();
        
        // Act
        userRole.Update(updatedUserRole);

        // Assert
        userRole.DomainEvents.Count.Should().Be(1);
        userRole.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(UserRoleUpdated));
    }
}