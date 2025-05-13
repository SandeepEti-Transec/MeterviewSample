namespace MeterView.DeviceAlert.API.Domain.DeviceAlerts.Dtos;

using MeterView.DeviceAlert.API.Resources;

public sealed class DeviceAlertParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
