namespace MeterView.Identity.API.IntegrationTests.FeatureTests.UserOgranizations;

using MeterView.Identity.API.SharedTestHelpers.Fakes.UserOgranization;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MeterView.Identity.API.Domain.UserOgranizations.Features;

public class AddUserOgranizationCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_userogranization_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var userOgranizationOne = new FakeUserOgranizationForCreationDto().Generate();

        // Act
        var command = new AddUserOgranization.Command(userOgranizationOne);
        var userOgranizationReturned = await testingServiceScope.SendAsync(command);
        var userOgranizationCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.UserOgranizations
            .FirstOrDefaultAsync(u => u.Id == userOgranizationReturned.Id));

        // Assert
        userOgranizationReturned.UserId.Should().Be(userOgranizationOne.UserId);
        userOgranizationReturned.OrganizationId.Should().Be(userOgranizationOne.OrganizationId);

        userOgranizationCreated.UserId.Should().Be(userOgranizationOne.UserId);
        userOgranizationCreated.OrganizationId.Should().Be(userOgranizationOne.OrganizationId);
    }
}