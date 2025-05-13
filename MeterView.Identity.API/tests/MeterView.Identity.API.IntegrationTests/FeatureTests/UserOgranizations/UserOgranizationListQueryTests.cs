namespace MeterView.Identity.API.IntegrationTests.FeatureTests.UserOgranizations;

using MeterView.Identity.API.Domain.UserOgranizations.Dtos;
using MeterView.Identity.API.SharedTestHelpers.Fakes.UserOgranization;
using MeterView.Identity.API.Domain.UserOgranizations.Features;
using Domain;
using System.Threading.Tasks;

public class UserOgranizationListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_userogranization_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var userOgranizationOne = new FakeUserOgranizationBuilder().Build();
        var userOgranizationTwo = new FakeUserOgranizationBuilder().Build();
        var queryParameters = new UserOgranizationParametersDto();

        await testingServiceScope.InsertAsync(userOgranizationOne, userOgranizationTwo);

        // Act
        var query = new GetUserOgranizationList.Query(queryParameters);
        var userOgranizations = await testingServiceScope.SendAsync(query);

        // Assert
        userOgranizations.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}