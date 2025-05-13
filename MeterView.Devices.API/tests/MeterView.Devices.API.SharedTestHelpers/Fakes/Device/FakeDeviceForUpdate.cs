namespace MeterView.Devices.API.SharedTestHelpers.Fakes.Device;

using AutoBogus;
using MeterView.Devices.API.Domain.Devices;
using MeterView.Devices.API.Domain.Devices.Models;

public sealed class FakeDeviceForUpdate : AutoFaker<DeviceForUpdate>
{
    public FakeDeviceForUpdate()
    {
    }
}