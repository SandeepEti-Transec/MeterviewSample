namespace MeterView.DeviceAlert.API.Domain.DeviceAlerts.Mappings;

using MeterView.DeviceAlert.API.Domain.DeviceAlerts.Dtos;
using MeterView.DeviceAlert.API.Domain.DeviceAlerts.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class DeviceAlertMapper
{
    public static partial DeviceAlertForCreation ToDeviceAlertForCreation(this DeviceAlertForCreationDto deviceAlertForCreationDto);
    public static partial DeviceAlertForUpdate ToDeviceAlertForUpdate(this DeviceAlertForUpdateDto deviceAlertForUpdateDto);
    public static partial DeviceAlertDto ToDeviceAlertDto(this DeviceAlert deviceAlert);
    public static partial IQueryable<DeviceAlertDto> ToDeviceAlertDtoQueryable(this IQueryable<DeviceAlert> deviceAlert);
}