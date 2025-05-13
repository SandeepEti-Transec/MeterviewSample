namespace MeterView.Devices.API.IntegrationTests.FeatureTests.Devices;

using MeterView.Devices.API.SharedTestHelpers.Fakes.Device;
using MeterView.Devices.API.Domain.Devices.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteDeviceCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_device_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var device = new FakeDeviceBuilder().Build();
        await testingServiceScope.InsertAsync(device);

        // Act
        var command = new DeleteDevice.Command(device.Id);
        await testingServiceScope.SendAsync(command);
        var deviceResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.Devices
                .CountAsync(d => d.Id == device.Id));

        // Assert
        deviceResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_device_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteDevice.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_device_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var device = new FakeDeviceBuilder().Build();
        await testingServiceScope.InsertAsync(device);

        // Act
        var command = new DeleteDevice.Command(device.Id);
        await testingServiceScope.SendAsync(command);
        var deletedDevice = await testingServiceScope.ExecuteDbContextAsync(db => db.Devices
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == device.Id));

        // Assert
        deletedDevice?.IsDeleted.Should().BeTrue();
    }
}