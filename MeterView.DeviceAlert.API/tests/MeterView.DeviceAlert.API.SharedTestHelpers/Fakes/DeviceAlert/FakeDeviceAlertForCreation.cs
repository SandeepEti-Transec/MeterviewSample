namespace MeterView.DeviceAlert.API.SharedTestHelpers.Fakes.DeviceAlert;

using AutoBogus;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts.Models;

public sealed class FakeDeviceAlertForCreation : AutoFaker<DeviceAlertForCreation>
{
    public FakeDeviceAlertForCreation()
    {
    }
}