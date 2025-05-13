namespace MeterView.Identity.API.IntegrationTests.FeatureTests.Organizations;

using MeterView.Identity.API.SharedTestHelpers.Fakes.Organization;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MeterView.Identity.API.Domain.Organizations.Features;

public class AddOrganizationCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_organization_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var organizationOne = new FakeOrganizationForCreationDto().Generate();

        // Act
        var command = new AddOrganization.Command(organizationOne);
        var organizationReturned = await testingServiceScope.SendAsync(command);
        var organizationCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Organizations
            .FirstOrDefaultAsync(o => o.Id == organizationReturned.Id));

        // Assert
        organizationReturned.Name.Should().Be(organizationOne.Name);
        organizationReturned.PrimaryDomain.Should().Be(organizationOne.PrimaryDomain);
        organizationReturned.IsActive.Should().Be(organizationOne.IsActive);

        organizationCreated.Name.Should().Be(organizationOne.Name);
        organizationCreated.PrimaryDomain.Should().Be(organizationOne.PrimaryDomain);
        organizationCreated.IsActive.Should().Be(organizationOne.IsActive);
    }
}