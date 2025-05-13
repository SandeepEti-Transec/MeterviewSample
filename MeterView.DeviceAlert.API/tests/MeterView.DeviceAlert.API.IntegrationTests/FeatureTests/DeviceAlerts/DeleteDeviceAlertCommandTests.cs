namespace MeterView.DeviceAlert.API.IntegrationTests.FeatureTests.DeviceAlerts;

using MeterView.DeviceAlert.API.SharedTestHelpers.Fakes.DeviceAlert;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts.Features;
using Microsoft.EntityFrameworkCore;
using Domain;
using System.Threading.Tasks;

public class DeleteDeviceAlertCommandTests : TestBase
{
    [Fact]
    public async Task can_delete_devicealert_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var deviceAlert = new FakeDeviceAlertBuilder().Build();
        await testingServiceScope.InsertAsync(deviceAlert);

        // Act
        var command = new DeleteDeviceAlert.Command(deviceAlert.Id);
        await testingServiceScope.SendAsync(command);
        var deviceAlertResponse = await testingServiceScope
            .ExecuteDbContextAsync(db => db.DeviceAlerts
                .CountAsync(d => d.Id == deviceAlert.Id));

        // Assert
        deviceAlertResponse.Should().Be(0);
    }

    [Fact]
    public async Task delete_devicealert_throws_notfoundexception_when_record_does_not_exist()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var badId = Guid.NewGuid();

        // Act
        var command = new DeleteDeviceAlert.Command(badId);
        Func<Task> act = () => testingServiceScope.SendAsync(command);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }

    [Fact]
    public async Task can_softdelete_devicealert_from_db()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var deviceAlert = new FakeDeviceAlertBuilder().Build();
        await testingServiceScope.InsertAsync(deviceAlert);

        // Act
        var command = new DeleteDeviceAlert.Command(deviceAlert.Id);
        await testingServiceScope.SendAsync(command);
        var deletedDeviceAlert = await testingServiceScope.ExecuteDbContextAsync(db => db.DeviceAlerts
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == deviceAlert.Id));

        // Assert
        deletedDeviceAlert?.IsDeleted.Should().BeTrue();
    }
}