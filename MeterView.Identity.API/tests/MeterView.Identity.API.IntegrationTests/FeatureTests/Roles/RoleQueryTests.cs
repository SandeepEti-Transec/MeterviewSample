namespace MeterView.Identity.API.IntegrationTests.FeatureTests.Roles;

using MeterView.Identity.API.SharedTestHelpers.Fakes.Role;
using MeterView.Identity.API.Domain.Roles.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class RoleQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_role_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var roleOne = new FakeRoleBuilder().Build();
        await testingServiceScope.InsertAsync(roleOne);

        // Act
        var query = new GetRole.Query(roleOne.Id);
        var role = await testingServiceScope.SendAsync(query);

        // Assert
        role.Key.Should().Be(roleOne.Key);
        role.DisplayName.Should().Be(roleOne.DisplayName);
        role.Group.Should().Be(roleOne.Group);
    }

    [Fact]
    public async Task get_role_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetRole.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}