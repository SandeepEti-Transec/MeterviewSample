namespace MeterView.Identity.API.Domain.Organizations.Dtos;

using MeterView.Identity.API.Resources;

public sealed class OrganizationParametersDto : BasePaginationParameters
{
    public string? Filters { get; set; }
    public string? SortOrder { get; set; }
}
