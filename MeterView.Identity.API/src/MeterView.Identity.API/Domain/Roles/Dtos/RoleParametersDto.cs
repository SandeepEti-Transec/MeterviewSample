namespace MeterView.Identity.API.Domain.Roles.Dtos;

using MeterView.Identity.API.Resources;

public sealed class RoleParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
