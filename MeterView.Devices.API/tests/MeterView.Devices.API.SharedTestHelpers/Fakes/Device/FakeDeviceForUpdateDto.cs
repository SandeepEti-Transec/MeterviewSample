namespace MeterView.Devices.API.SharedTestHelpers.Fakes.Device;

using AutoBogus;
using MeterView.Devices.API.Domain.Devices;
using MeterView.Devices.API.Domain.Devices.Dtos;

public sealed class FakeDeviceForUpdateDto : AutoFaker<DeviceForUpdateDto>
{
    public FakeDeviceForUpdateDto()
    {
    }
}