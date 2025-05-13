namespace MeterView.DeviceAlert.API.UnitTests.Domain.DeviceAlerts;

using MeterView.DeviceAlert.API.SharedTestHelpers.Fakes.DeviceAlert;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts.DomainEvents;
using Bogus;
using FluentAssertions.Extensions;
using ValidationException = MeterView.DeviceAlert.API.Exceptions.ValidationException;

public class CreateDeviceAlertTests
{
    private readonly Faker _faker;

    public CreateDeviceAlertTests()
    {
        _faker = new Faker();
    }
    
    [Fact]
    public void can_create_valid_deviceAlert()
    {
        // Arrange
        var deviceAlertToCreate = new FakeDeviceAlertForCreation().Generate();
        
        // Act
        var deviceAlert = DeviceAlert.Create(deviceAlertToCreate);

        // Assert
        deviceAlert.Title.Should().Be(deviceAlertToCreate.Title);
        deviceAlert.Isactive.Should().Be(deviceAlertToCreate.Isactive);
    }

    [Fact]
    public void queue_domain_event_on_create()
    {
        // Arrange
        var deviceAlertToCreate = new FakeDeviceAlertForCreation().Generate();
        
        // Act
        var deviceAlert = DeviceAlert.Create(deviceAlertToCreate);

        // Assert
        deviceAlert.DomainEvents.Count.Should().Be(1);
        deviceAlert.DomainEvents.FirstOrDefault().Should().BeOfType(typeof(DeviceAlertCreated));
    }
}