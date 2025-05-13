namespace MeterView.Identity.API.IntegrationTests.FeatureTests.UserRoles;

using MeterView.Identity.API.SharedTestHelpers.Fakes.UserRole;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MeterView.Identity.API.Domain.UserRoles.Features;

public class AddUserRoleCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_userrole_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var userRoleOne = new FakeUserRoleForCreationDto().Generate();

        // Act
        var command = new AddUserRole.Command(userRoleOne);
        var userRoleReturned = await testingServiceScope.SendAsync(command);
        var userRoleCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.UserRoles
            .FirstOrDefaultAsync(u => u.Id == userRoleReturned.Id));

        // Assert
        userRoleReturned.UserId.Should().Be(userRoleOne.UserId);
        userRoleReturned.RoleId.Should().Be(userRoleOne.RoleId);

        userRoleCreated.UserId.Should().Be(userRoleOne.UserId);
        userRoleCreated.RoleId.Should().Be(userRoleOne.RoleId);
    }
}