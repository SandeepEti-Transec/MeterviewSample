namespace MeterView.Identity.API.IntegrationTests.FeatureTests.UserRoles;

using MeterView.Identity.API.SharedTestHelpers.Fakes.UserRole;
using MeterView.Identity.API.Domain.UserRoles.Dtos;
using MeterView.Identity.API.Domain.UserRoles.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateUserRoleCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_userrole_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var userRole = new FakeUserRoleBuilder().Build();
        await testingServiceScope.InsertAsync(userRole);
        var updatedUserRoleDto = new FakeUserRoleForUpdateDto().Generate();

        // Act
        var command = new UpdateUserRole.Command(userRole.Id, updatedUserRoleDto);
        await testingServiceScope.SendAsync(command);
        var updatedUserRole = await testingServiceScope
            .ExecuteDbContextAsync(db => db.UserRoles
                .FirstOrDefaultAsync(u => u.Id == userRole.Id));

        // Assert
        updatedUserRole.UserId.Should().Be(updatedUserRoleDto.UserId);
        updatedUserRole.RoleId.Should().Be(updatedUserRoleDto.RoleId);
    }
}