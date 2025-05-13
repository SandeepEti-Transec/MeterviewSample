namespace MeterView.Devices.API.Domain.Devices.Dtos;

using MeterView.Devices.API.Resources;

public sealed class DeviceParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
