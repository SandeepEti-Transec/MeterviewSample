namespace MeterView.DeviceAlert.API.IntegrationTests.FeatureTests.DeviceAlerts;

using MeterView.DeviceAlert.API.SharedTestHelpers.Fakes.DeviceAlert;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts.Dtos;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateDeviceAlertCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_devicealert_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var deviceAlert = new FakeDeviceAlertBuilder().Build();
        await testingServiceScope.InsertAsync(deviceAlert);
        var updatedDeviceAlertDto = new FakeDeviceAlertForUpdateDto().Generate();

        // Act
        var command = new UpdateDeviceAlert.Command(deviceAlert.Id, updatedDeviceAlertDto);
        await testingServiceScope.SendAsync(command);
        var updatedDeviceAlert = await testingServiceScope
            .ExecuteDbContextAsync(db => db.DeviceAlerts
                .FirstOrDefaultAsync(d => d.Id == deviceAlert.Id));

        // Assert
        updatedDeviceAlert.Title.Should().Be(updatedDeviceAlertDto.Title);
        updatedDeviceAlert.Isactive.Should().Be(updatedDeviceAlertDto.Isactive);
    }
}