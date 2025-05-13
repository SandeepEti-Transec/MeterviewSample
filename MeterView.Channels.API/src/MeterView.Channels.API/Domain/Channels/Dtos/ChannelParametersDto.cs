namespace MeterView.Channels.API.Domain.Channels.Dtos;

using MeterView.Channels.API.Resources;

public sealed class ChannelParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
