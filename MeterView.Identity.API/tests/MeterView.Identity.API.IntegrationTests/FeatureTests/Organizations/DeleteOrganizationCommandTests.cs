namespace MeterView.Identity.API.IntegrationTests.FeatureTests.Organizations;

using MeterView.Identity.API.SharedTestHelpers.Fakes.Organization;
using MeterView.Identity.API.Domain.Organizations.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteOrganizationCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_organization_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var organization = new FakeOrganizationBuilder().Build();
        await testingServiceScope.InsertAsync(organization);

        // Act
        var command = new DeleteOrganization.Command(organization.Id);
        await testingServiceScope.SendAsync(command);
        var organizationResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Organizations
                .CountAsync(o => o.Id == organization.Id));

        // Assert
        organizationResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_organization_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteOrganization.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_organization_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var organization = new FakeOrganizationBuilder().Build();
        await testingServiceScope.InsertAsync(organization);

        // Act
        var command = new DeleteOrganization.Command(organization.Id);
        await testingServiceScope.SendAsync(command);
        var deletedOrganization = await testingServiceScope.ExecuteDbContextAsync(db => db.Organizations
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == organization.Id));

        // Assert
        deletedOrganization?.IsDeleted.Should().BeTrue();
    }
}