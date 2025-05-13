namespace MeterView.DeviceAlert.API.IntegrationTests.FeatureTests.DeviceAlerts;

using MeterView.DeviceAlert.API.SharedTestHelpers.Fakes.DeviceAlert;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts.Features;

public class AddDeviceAlertCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_devicealert_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var deviceAlertOne = new FakeDeviceAlertForCreationDto().Generate();

        // Act
        var command = new AddDeviceAlert.Command(deviceAlertOne);
        var deviceAlertReturned = await testingServiceScope.SendAsync(command);
        var deviceAlertCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.DeviceAlerts
            .FirstOrDefaultAsync(d => d.Id == deviceAlertReturned.Id));

        // Assert
        deviceAlertReturned.Title.Should().Be(deviceAlertOne.Title);
        deviceAlertReturned.Isactive.Should().Be(deviceAlertOne.Isactive);

        deviceAlertCreated.Title.Should().Be(deviceAlertOne.Title);
        deviceAlertCreated.Isactive.Should().Be(deviceAlertOne.Isactive);
    }
}