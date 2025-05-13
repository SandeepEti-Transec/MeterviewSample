namespace MeterView.DeviceAlert.API.UnitTests.Domain.DeviceAlerts;

using MeterView.DeviceAlert.API.SharedTestHelpers.Fakes.DeviceAlert;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.DeviceAlert.API.Exceptions.ValidationException;

public class UpdateDeviceAlertTests
{
    private readonly Faker _faker;

    public UpdateDeviceAlertTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_update_deviceAlert()
    {
        // Arrange
        var deviceAlert = new FakeDeviceAlertBuilder().Build();
        var updatedDeviceAlert = new FakeDeviceAlertForUpdate().Generate();
        
        // Act
        deviceAlert.Update(updatedDeviceAlert);

        // Assert
        deviceAlert.Title.Should().Be(updatedDeviceAlert.Title);
        deviceAlert.Isactive.Should().Be(updatedDeviceAlert.Isactive);
    }
    
    [Fact]
    public void queue_domain_event_on_update()
    {
        // Arrange
        var deviceAlert = new FakeDeviceAlertBuilder().Build();
        var updatedDeviceAlert = new FakeDeviceAlertForUpdate().Generate();
        deviceAlert.DomainEvents.Clear();
        
        // Act
        deviceAlert.Update(updatedDeviceAlert);

        // Assert
        deviceAlert.DomainEvents.Count.Should().Be(1);
        deviceAlert.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(DeviceAlertUpdated));
    }
}