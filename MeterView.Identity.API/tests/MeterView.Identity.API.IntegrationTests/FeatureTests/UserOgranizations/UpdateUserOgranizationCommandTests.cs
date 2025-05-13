namespace MeterView.Identity.API.IntegrationTests.FeatureTests.UserOgranizations;

using MeterView.Identity.API.SharedTestHelpers.Fakes.UserOgranization;
using MeterView.Identity.API.Domain.UserOgranizations.Dtos;
using MeterView.Identity.API.Domain.UserOgranizations.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateUserOgranizationCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_userogranization_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var userOgranization = new FakeUserOgranizationBuilder().Build();
        await testingServiceScope.InsertAsync(userOgranization);
        var updatedUserOgranizationDto = new FakeUserOgranizationForUpdateDto().Generate();

        // Act
        var command = new UpdateUserOgranization.Command(userOgranization.Id, updatedUserOgranizationDto);
        await testingServiceScope.SendAsync(command);
        var updatedUserOgranization = await testingServiceScope
            .ExecuteDbContextAsync(db => db.UserOgranizations
                .FirstOrDefaultAsync(u => u.Id == userOgranization.Id));

        // Assert
        updatedUserOgranization.UserId.Should().Be(updatedUserOgranizationDto.UserId);
        updatedUserOgranization.OrganizationId.Should().Be(updatedUserOgranizationDto.OrganizationId);
    }
}