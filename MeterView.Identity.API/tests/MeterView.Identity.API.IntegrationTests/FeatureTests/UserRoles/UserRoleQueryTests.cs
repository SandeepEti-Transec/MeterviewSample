namespace MeterView.Identity.API.IntegrationTests.FeatureTests.UserRoles;

using MeterView.Identity.API.SharedTestHelpers.Fakes.UserRole;
using MeterView.Identity.API.Domain.UserRoles.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UserRoleQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_userrole_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var userRoleOne = new FakeUserRoleBuilder().Build();
        await testingServiceScope.InsertAsync(userRoleOne);

        // Act
        var query = new GetUserRole.Query(userRoleOne.Id);
        var userRole = await testingServiceScope.SendAsync(query);

        // Assert
        userRole.UserId.Should().Be(userRoleOne.UserId);
        userRole.RoleId.Should().Be(userRoleOne.RoleId);
    }

    [Fact]
    public async Task get_userrole_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetUserRole.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}