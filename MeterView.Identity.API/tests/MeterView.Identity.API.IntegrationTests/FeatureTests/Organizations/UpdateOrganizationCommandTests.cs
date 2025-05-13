namespace MeterView.Identity.API.IntegrationTests.FeatureTests.Organizations;

using MeterView.Identity.API.SharedTestHelpers.Fakes.Organization;
using MeterView.Identity.API.Domain.Organizations.Dtos;
using MeterView.Identity.API.Domain.Organizations.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateOrganizationCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_organization_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var organization = new FakeOrganizationBuilder().Build();
        await testingServiceScope.InsertAsync(organization);
        var updatedOrganizationDto = new FakeOrganizationForUpdateDto().Generate();

        // Act
        var command = new UpdateOrganization.Command(organization.Id, updatedOrganizationDto);
        await testingServiceScope.SendAsync(command);
        var updatedOrganization = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Organizations
                .FirstOrDefaultAsync(o => o.Id == organization.Id));

        // Assert
        updatedOrganization.Name.Should().Be(updatedOrganizationDto.Name);
        updatedOrganization.PrimaryDomain.Should().Be(updatedOrganizationDto.PrimaryDomain);
        updatedOrganization.IsActive.Should().Be(updatedOrganizationDto.IsActive);
    }
}