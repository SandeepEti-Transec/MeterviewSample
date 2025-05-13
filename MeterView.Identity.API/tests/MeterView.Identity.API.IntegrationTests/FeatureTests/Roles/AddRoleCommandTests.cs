namespace MeterView.Identity.API.IntegrationTests.FeatureTests.Roles;

using MeterView.Identity.API.SharedTestHelpers.Fakes.Role;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MeterView.Identity.API.Domain.Roles.Features;

public class AddRoleCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_role_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var roleOne = new FakeRoleForCreationDto().Generate();

        // Act
        var command = new AddRole.Command(roleOne);
        var roleReturned = await testingServiceScope.SendAsync(command);
        var roleCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Roles
            .FirstOrDefaultAsync(r => r.Id == roleReturned.Id));

        // Assert
        roleReturned.Key.Should().Be(roleOne.Key);
        roleReturned.DisplayName.Should().Be(roleOne.DisplayName);
        roleReturned.Group.Should().Be(roleOne.Group);

        roleCreated.Key.Should().Be(roleOne.Key);
        roleCreated.DisplayName.Should().Be(roleOne.DisplayName);
        roleCreated.Group.Should().Be(roleOne.Group);
    }
}