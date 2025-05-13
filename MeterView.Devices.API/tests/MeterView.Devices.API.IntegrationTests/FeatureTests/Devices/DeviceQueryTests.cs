namespace MeterView.Devices.API.IntegrationTests.FeatureTests.Devices;

using MeterView.Devices.API.SharedTestHelpers.Fakes.Device;
using MeterView.Devices.API.Domain.Devices.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class DeviceQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_device_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var deviceOne = new FakeDeviceBuilder().Build();
        await testingServiceScope.InsertAsync(deviceOne);

        // Act
        var query = new GetDevice.Query(deviceOne.Id);
        var device = await testingServiceScope.SendAsync(query);

        // Assert
        device.Name.Should().Be(deviceOne.Name);
        device.LocationTag.Should().Be(deviceOne.LocationTag);
        device.Location.Should().Be(deviceOne.Location);
        device.Status.Should().Be(deviceOne.Status);
    }

    [Fact]
    public async Task get_device_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetDevice.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}