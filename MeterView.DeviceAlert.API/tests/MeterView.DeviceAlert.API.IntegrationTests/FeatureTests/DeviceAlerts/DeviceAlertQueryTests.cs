namespace MeterView.DeviceAlert.API.IntegrationTests.FeatureTests.DeviceAlerts;

using MeterView.DeviceAlert.API.SharedTestHelpers.Fakes.DeviceAlert;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts.Features;
using Domain;
using FluentAssertions.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class DeviceAlertQueryTests : TestBase
{
    [Fact]
    public async Task can_get_existing_devicealert_with_accurate_props()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var deviceAlertOne = new FakeDeviceAlertBuilder().Build();
        await testingServiceScope.InsertAsync(deviceAlertOne);

        // Act
        var query = new GetDeviceAlert.Query(deviceAlertOne.Id);
        var deviceAlert = await testingServiceScope.SendAsync(query);

        // Assert
        deviceAlert.Title.Should().Be(deviceAlertOne.Title);
        deviceAlert.Isactive.Should().Be(deviceAlertOne.Isactive);
    }

    [Fact]
    public async Task get_devicealert_throws_notfound_exception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var query = new GetDeviceAlert.Query(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(query);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}