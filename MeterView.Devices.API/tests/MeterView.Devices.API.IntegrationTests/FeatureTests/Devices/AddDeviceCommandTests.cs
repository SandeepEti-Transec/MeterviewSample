namespace MeterView.Devices.API.IntegrationTests.FeatureTests.Devices;

using MeterView.Devices.API.SharedTestHelpers.Fakes.Device;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MeterView.Devices.API.Domain.Devices.Features;

public class AddDeviceCommandTests : TestBase
{
    [Fact]
    public async Task can_add_new_device_to_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var deviceOne = new FakeDeviceForCreationDto().Generate();

        // Act
        var command = new AddDevice.Command(deviceOne);
        var deviceReturned = await testingServiceScope.SendAsync(command);
        var deviceCreated = await testingServiceScope.ExecuteDbContextAsync(db => db.Devices
            .FirstOrDefaultAsync(d => d.Id == deviceReturned.Id));

        // Assert
        deviceReturned.Name.Should().Be(deviceOne.Name);
        deviceReturned.LocationTag.Should().Be(deviceOne.LocationTag);
        deviceReturned.Location.Should().Be(deviceOne.Location);
        deviceReturned.Status.Should().Be(deviceOne.Status);

        deviceCreated.Name.Should().Be(deviceOne.Name);
        deviceCreated.LocationTag.Should().Be(deviceOne.LocationTag);
        deviceCreated.Location.Should().Be(deviceOne.Location);
        deviceCreated.Status.Should().Be(deviceOne.Status);
    }
}