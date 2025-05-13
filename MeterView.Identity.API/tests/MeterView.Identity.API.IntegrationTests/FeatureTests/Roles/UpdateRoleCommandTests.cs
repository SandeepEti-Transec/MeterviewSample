namespace MeterView.Identity.API.IntegrationTests.FeatureTests.Roles;

using MeterView.Identity.API.SharedTestHelpers.Fakes.Role;
using MeterView.Identity.API.Domain.Roles.Dtos;
using MeterView.Identity.API.Domain.Roles.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateRoleCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_role_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var role = new FakeRoleBuilder().Build();
        await testingServiceScope.InsertAsync(role);
        var updatedRoleDto = new FakeRoleForUpdateDto().Generate();

        // Act
        var command = new UpdateRole.Command(role.Id, updatedRoleDto);
        await testingServiceScope.SendAsync(command);
        var updatedRole = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Roles
                .FirstOrDefaultAsync(r => r.Id == role.Id));

        // Assert
        updatedRole.Key.Should().Be(updatedRoleDto.Key);
        updatedRole.DisplayName.Should().Be(updatedRoleDto.DisplayName);
        updatedRole.Group.Should().Be(updatedRoleDto.Group);
    }
}