namespace MeterView.Devices.API.UnitTests.Domain.Devices;

using MeterView.Devices.API.SharedTestHelpers.Fakes.Device;
using MeterView.Devices.API.Domain.Devices;
using MeterView.Devices.API.Domain.Devices.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.Devices.API.Exceptions.ValidationException;

public class UpdateDeviceTests
{
    private readonly Faker _faker;

    public UpdateDeviceTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_device()
    {
        // Arrange
        var device = new FakeDeviceBuilder().Build();
        var updatedDevice = new FakeDeviceForUpdate().Generate();
        
        // Act
        device.Update(updatedDevice);

        // Assert
        device.Name.Should().Be(updatedDevice.Name);
        device.LocationTag.Should().Be(updatedDevice.LocationTag);
        device.Location.Should().Be(updatedDevice.Location);
        device.Status.Should().Be(updatedDevice.Status);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var device = new FakeDeviceBuilder().Build();
        var updatedDevice = new FakeDeviceForUpdate().Generate();
        device.DomainEvents.Clear();
        
        // Act
        device.Update(updatedDevice);

        // Assert
        device.DomainEvents.Count.Should().Be(1);
        device.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(DeviceUpdated));
    }
}