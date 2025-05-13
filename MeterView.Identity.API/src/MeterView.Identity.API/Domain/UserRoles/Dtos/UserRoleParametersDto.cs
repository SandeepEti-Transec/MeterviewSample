namespace MeterView.Identity.API.Domain.UserRoles.Dtos;

using MeterView.Identity.API.Resources;

public sealed class UserRoleParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
