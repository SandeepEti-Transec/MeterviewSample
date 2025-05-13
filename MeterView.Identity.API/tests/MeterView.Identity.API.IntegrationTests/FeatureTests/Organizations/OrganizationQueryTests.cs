namespace MeterView.Identity.API.IntegrationTests.FeatureTests.Organizations;

using MeterView.Identity.API.SharedTestHelpers.Fakes.Organization;
using MeterView.Identity.API.Domain.Organizations.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class OrganizationQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_organization_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var organizationOne = new FakeOrganizationBuilder().Build();
        await testingServiceScope.InsertAsync(organizationOne);

        // Act
        var query = new GetOrganization.Query(organizationOne.Id);
        var organization = await testingServiceScope.SendAsync(query);

        // Assert
        organization.Name.Should().Be(organizationOne.Name);
        organization.PrimaryDomain.Should().Be(organizationOne.PrimaryDomain);
        organization.IsActive.Should().Be(organizationOne.IsActive);
    }

    [Fact]
    public async Task get_organization_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetOrganization.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}