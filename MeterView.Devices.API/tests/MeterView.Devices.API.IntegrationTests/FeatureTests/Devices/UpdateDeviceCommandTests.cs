namespace MeterView.Devices.API.IntegrationTests.FeatureTests.Devices;

using MeterView.Devices.API.SharedTestHelpers.Fakes.Device;
using MeterView.Devices.API.Domain.Devices.Dtos;
using MeterView.Devices.API.Domain.Devices.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UpdateDeviceCommandTests : TestBase
{
    [Fact]
    public async Task can_update_existing_device_in_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var device = new FakeDeviceBuilder().Build();
        await testingServiceScope.InsertAsync(device);
        var updatedDeviceDto = new FakeDeviceForUpdateDto().Generate();

        // Act
        var command = new UpdateDevice.Command(device.Id, updatedDeviceDto);
        await testingServiceScope.SendAsync(command);
        var updatedDevice = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Devices
                .FirstOrDefaultAsync(d => d.Id == device.Id));

        // Assert
        updatedDevice.Name.Should().Be(updatedDeviceDto.Name);
        updatedDevice.LocationTag.Should().Be(updatedDeviceDto.LocationTag);
        updatedDevice.Location.Should().Be(updatedDeviceDto.Location);
        updatedDevice.Status.Should().Be(updatedDeviceDto.Status);
    }
}