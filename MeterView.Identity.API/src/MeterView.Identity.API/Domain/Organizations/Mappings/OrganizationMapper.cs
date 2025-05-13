namespace MeterView.Identity.API.Domain.Organizations.Mappings;

using MeterView.Identity.API.Domain.Organizations.Dtos;
using MeterView.Identity.API.Domain.Organizations.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class OrganizationMapper
{
    public static partial OrganizationForCreation ToOrganizationForCreation(this OrganizationForCreationDto organizationForCreationDto);
    public static partial OrganizationForUpdate ToOrganizationForUpdate(this OrganizationForUpdateDto organizationForUpdateDto);
    public static partial OrganizationDto ToOrganizationDto(this Organization organization);
    public static partial IQueryable<OrganizationDto> ToOrganizationDtoQueryable(this IQueryable<Organization> organization);
}