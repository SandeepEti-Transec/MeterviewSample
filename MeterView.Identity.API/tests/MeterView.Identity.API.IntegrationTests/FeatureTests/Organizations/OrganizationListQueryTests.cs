namespace MeterView.Identity.API.IntegrationTests.FeatureTests.Organizations;

using MeterView.Identity.API.Domain.Organizations.Dtos;
using MeterView.Identity.API.SharedTestHelpers.Fakes.Organization;
using MeterView.Identity.API.Domain.Organizations.Features;
using Domain;
using System.Threading.Tasks;

public class OrganizationListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_organization_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var organizationOne = new FakeOrganizationBuilder().Build();
        var organizationTwo = new FakeOrganizationBuilder().Build();
        var queryParameters = new OrganizationParametersDto();

        await testingServiceScope.InsertAsync(organizationOne, organizationTwo);

        // Act
        var query = new GetOrganizationList.Query(queryParameters);
        var organizations = await testingServiceScope.SendAsync(query);

        // Assert
        organizations.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}