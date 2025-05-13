namespace MeterView.Devices.API.Domain.Devices.Mappings;

using MeterView.Devices.API.Domain.Devices.Dtos;
using MeterView.Devices.API.Domain.Devices.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class DeviceMapper
{
    public static partial DeviceForCreation ToDeviceForCreation(this DeviceForCreationDto deviceForCreationDto);
    public static partial DeviceForUpdate ToDeviceForUpdate(this DeviceForUpdateDto deviceForUpdateDto);
    public static partial DeviceDto ToDeviceDto(this Device device);
    public static partial IQueryable<DeviceDto> ToDeviceDtoQueryable(this IQueryable<Device> device);
}