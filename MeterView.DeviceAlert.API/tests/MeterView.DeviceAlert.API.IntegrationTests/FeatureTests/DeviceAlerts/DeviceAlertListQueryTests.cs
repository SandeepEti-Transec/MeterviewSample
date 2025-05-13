namespace MeterView.DeviceAlert.API.IntegrationTests.FeatureTests.DeviceAlerts;

using MeterView.DeviceAlert.API.Domain.DeviceAlerts.Dtos;
using MeterView.DeviceAlert.API.SharedTestHelpers.Fakes.DeviceAlert;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts.Features;
using Domain;
using System.Threading.Tasks;

public class DeviceAlertListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_devicealert_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var deviceAlertOne = new FakeDeviceAlertBuilder().Build();
        var deviceAlertTwo = new FakeDeviceAlertBuilder().Build();
        var queryParameters = new DeviceAlertParametersDto();

        await testingServiceScope.InsertAsync(deviceAlertOne, deviceAlertTwo);

        // Act
        var query = new GetDeviceAlertList.Query(queryParameters);
        var deviceAlerts = await testingServiceScope.SendAsync(query);

        // Assert
        deviceAlerts.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}