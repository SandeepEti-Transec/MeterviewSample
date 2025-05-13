namespace MeterView.Identity.API.IntegrationTests.FeatureTests.UserOgranizations;

using MeterView.Identity.API.SharedTestHelpers.Fakes.UserOgranization;
using MeterView.Identity.API.Domain.UserOgranizations.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UserOgranizationQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_userogranization_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var userOgranizationOne = new FakeUserOgranizationBuilder().Build();
        await testingServiceScope.InsertAsync(userOgranizationOne);

        // Act
        var query = new GetUserOgranization.Query(userOgranizationOne.Id);
        var userOgranization = await testingServiceScope.SendAsync(query);

        // Assert
        userOgranization.UserId.Should().Be(userOgranizationOne.UserId);
        userOgranization.OrganizationId.Should().Be(userOgranizationOne.OrganizationId);
    }

    [Fact]
    public async Task get_userogranization_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetUserOgranization.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}