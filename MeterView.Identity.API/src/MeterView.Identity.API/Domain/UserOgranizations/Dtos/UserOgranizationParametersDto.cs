namespace MeterView.Identity.API.Domain.UserOgranizations.Dtos;

using MeterView.Identity.API.Resources;

public sealed class UserOgranizationParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
