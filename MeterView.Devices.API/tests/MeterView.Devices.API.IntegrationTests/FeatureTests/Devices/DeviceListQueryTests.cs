namespace MeterView.Devices.API.IntegrationTests.FeatureTests.Devices;

using MeterView.Devices.API.Domain.Devices.Dtos;
using MeterView.Devices.API.SharedTestHelpers.Fakes.Device;
using MeterView.Devices.API.Domain.Devices.Features;
using Domain;
using System.Threading.Tasks;

public class DeviceListQueryTests : TestBase
{
    
    [Fact]
    public async Task can_get_device_list()
    {
        // Arrange
        var testingServiceScope = new TestingServiceScope();
        var deviceOne = new FakeDeviceBuilder().Build();
        var deviceTwo = new FakeDeviceBuilder().Build();
        var queryParameters = new DeviceParametersDto();

        await testingServiceScope.InsertAsync(deviceOne, deviceTwo);

        // Act
        var query = new GetDeviceList.Query(queryParameters);
        var devices = await testingServiceScope.SendAsync(query);

        // Assert
        devices.Count.Should().BeGreaterThanOrEqualTo(2);
    }
}