namespace MeterView.Devices.API.UnitTests.Domain.Devices;

using MeterView.Devices.API.SharedTestHelpers.Fakes.Device;
using MeterView.Devices.API.Domain.Devices;
using MeterView.Devices.API.Domain.Devices.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.Devices.API.Exceptions.ValidationException;

public class CreateDeviceTests
{
    private readonly Faker _faker;

    public CreateDeviceTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_device()
    {
        // Arrange
        var deviceToCreate = new FakeDeviceForCreation().Generate();
        
        // Act
        var device = Device.Create(deviceToCreate);

        // Assert
        device.Name.Should().Be(deviceToCreate.Name);
        device.LocationTag.Should().Be(deviceToCreate.LocationTag);
        device.Location.Should().Be(deviceToCreate.Location);
        device.Status.Should().Be(deviceToCreate.Status);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var deviceToCreate = new FakeDeviceForCreation().Generate();
        
        // Act
        var device = Device.Create(deviceToCreate);

        // Assert
        device.DomainEvents.Count.Should().Be(1);
        device.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(DeviceCreated));
    }
}