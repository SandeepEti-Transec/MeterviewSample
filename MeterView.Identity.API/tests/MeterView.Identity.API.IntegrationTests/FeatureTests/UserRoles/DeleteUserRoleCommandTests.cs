namespace MeterView.Identity.API.IntegrationTests.FeatureTests.UserRoles;

using MeterView.Identity.API.SharedTestHelpers.Fakes.UserRole;
using MeterView.Identity.API.Domain.UserRoles.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteUserRoleCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_userrole_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var userRole = new FakeUserRoleBuilder().Build();
        await testingServiceScope.InsertAsync(userRole);

        // Act
        var command = new DeleteUserRole.Command(userRole.Id);
        await testingServiceScope.SendAsync(command);
        var userRoleResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.UserRoles
                .CountAsync(u => u.Id == userRole.Id));

        // Assert
        userRoleResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_userrole_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteUserRole.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_userrole_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var userRole = new FakeUserRoleBuilder().Build();
        await testingServiceScope.InsertAsync(userRole);

        // Act
        var command = new DeleteUserRole.Command(userRole.Id);
        await testingServiceScope.SendAsync(command);
        var deletedUserRole = await testingServiceScope.ExecuteDbContextAsync(db => db.UserRoles
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == userRole.Id));

        // Assert
        deletedUserRole?.IsDeleted.Should().BeTrue();
    }
}