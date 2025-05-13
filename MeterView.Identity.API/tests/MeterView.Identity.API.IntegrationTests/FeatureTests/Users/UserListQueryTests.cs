namespace MeterView.Identity.API.IntegrationTests.FeatureTests.Users;

using MeterView.Identity.API.Domain.Users.Dtos;
using MeterView.Identity.API.SharedTestHelpers.Fakes.User;
using MeterView.Identity.API.Domain.Users.Features;
using Domain;
using System.Threading.Tasks;

public class UserListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_user_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var userOne = new FakeUserBuilder().Build();
        var userTwo = new FakeUserBuilder().Build();
        var queryParameters = new UserParametersDto();

        await testingServiceScope.InsertAsync(userOne, userTwo);

        // Act
        var query = new GetUserList.Query(queryParameters);
        var users = await testingServiceScope.SendAsync(query);

        // Assert
        users.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}