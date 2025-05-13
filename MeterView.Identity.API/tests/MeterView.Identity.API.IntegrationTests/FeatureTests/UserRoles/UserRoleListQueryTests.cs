namespace MeterView.Identity.API.IntegrationTests.FeatureTests.UserRoles;

using MeterView.Identity.API.Domain.UserRoles.Dtos;
using MeterView.Identity.API.SharedTestHelpers.Fakes.UserRole;
using MeterView.Identity.API.Domain.UserRoles.Features;
using Domain;
using System.Threading.Tasks;

public class UserRoleListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_userrole_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var userRoleOne = new FakeUserRoleBuilder().Build();
        var userRoleTwo = new FakeUserRoleBuilder().Build();
        var queryParameters = new UserRoleParametersDto();

        await testingServiceScope.InsertAsync(userRoleOne, userRoleTwo);

        // Act
        var query = new GetUserRoleList.Query(queryParameters);
        var userRoles = await testingServiceScope.SendAsync(query);

        // Assert
        userRoles.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}