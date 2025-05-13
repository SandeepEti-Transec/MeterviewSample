namespace MeterView.Support.API.Domain.FeedBacks.Dtos;

using MeterView.Support.API.Resources;

public sealed class FeedBackParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
