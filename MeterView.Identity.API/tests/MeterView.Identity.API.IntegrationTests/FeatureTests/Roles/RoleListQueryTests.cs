namespace MeterView.Identity.API.IntegrationTests.FeatureTests.Roles;

using MeterView.Identity.API.Domain.Roles.Dtos;
using MeterView.Identity.API.SharedTestHelpers.Fakes.Role;
using MeterView.Identity.API.Domain.Roles.Features;
using Domain;
using System.Threading.Tasks;

public class RoleListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_role_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var roleOne = new FakeRoleBuilder().Build();
        var roleTwo = new FakeRoleBuilder().Build();
        var queryParameters = new RoleParametersDto();

        await testingServiceScope.InsertAsync(roleOne, roleTwo);

        // Act
        var query = new GetRoleList.Query(queryParameters);
        var roles = await testingServiceScope.SendAsync(query);

        // Assert
        roles.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}