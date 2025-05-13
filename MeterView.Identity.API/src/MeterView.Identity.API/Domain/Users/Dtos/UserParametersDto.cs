namespace MeterView.Identity.API.Domain.Users.Dtos;

using MeterView.Identity.API.Resources;

public sealed class UserParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
