namespace MeterView.DeviceAlert.API.SharedTestHelpers.Fakes.DeviceAlert;

using AutoBogus;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts.Dtos;

public sealed class FakeDeviceAlertForCreationDto : AutoFaker<DeviceAlertForCreationDto>
{
    public FakeDeviceAlertForCreationDto()
    {
    }
}