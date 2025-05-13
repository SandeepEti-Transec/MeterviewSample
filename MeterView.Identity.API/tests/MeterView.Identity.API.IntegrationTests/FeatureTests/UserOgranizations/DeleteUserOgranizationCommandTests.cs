namespace MeterView.Identity.API.IntegrationTests.FeatureTests.UserOgranizations;

using MeterView.Identity.API.SharedTestHelpers.Fakes.UserOgranization;
using MeterView.Identity.API.Domain.UserOgranizations.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteUserOgranizationCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_userogranization_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var userOgranization = new FakeUserOgranizationBuilder().Build();
        await testingServiceScope.InsertAsync(userOgranization);

        // Act
        var command = new DeleteUserOgranization.Command(userOgranization.Id);
        await testingServiceScope.SendAsync(command);
        var userOgranizationResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.UserOgranizations
                .CountAsync(u => u.Id == userOgranization.Id));

        // Assert
        userOgranizationResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_userogranization_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteUserOgranization.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_userogranization_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var userOgranization = new FakeUserOgranizationBuilder().Build();
        await testingServiceScope.InsertAsync(userOgranization);

        // Act
        var command = new DeleteUserOgranization.Command(userOgranization.Id);
        await testingServiceScope.SendAsync(command);
        var deletedUserOgranization = await testingServiceScope.ExecuteDbContextAsync(db => db.UserOgranizations
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == userOgranization.Id));

        // Assert
        deletedUserOgranization?.IsDeleted.Should().BeTrue();
    }
}