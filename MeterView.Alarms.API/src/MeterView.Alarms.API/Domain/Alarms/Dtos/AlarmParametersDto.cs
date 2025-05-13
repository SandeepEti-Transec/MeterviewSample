namespace MeterView.Alarms.API.Domain.Alarms.Dtos;

using MeterView.Alarms.API.Resources;

public sealed class AlarmParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
