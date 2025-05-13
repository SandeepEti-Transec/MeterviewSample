namespace MeterView.TrendLines.API.Domain.TrendLines.Dtos;

using MeterView.TrendLines.API.Resources;

public sealed class TrendLineParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
