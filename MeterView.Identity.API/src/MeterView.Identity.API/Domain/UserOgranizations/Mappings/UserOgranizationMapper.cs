namespace MeterView.Identity.API.Domain.UserOgranizations.Mappings;

using MeterView.Identity.API.Domain.UserOgranizations.Dtos;
using MeterView.Identity.API.Domain.UserOgranizations.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class UserOgranizationMapper
{
    public static partial UserOgranizationForCreation ToUserOgranizationForCreation(this UserOgranizationForCreationDto userOgranizationForCreationDto);
    public static partial UserOgranizationForUpdate ToUserOgranizationForUpdate(this UserOgranizationForUpdateDto userOgranizationForUpdateDto);
    public static partial UserOgranizationDto ToUserOgranizationDto(this UserOgranization userOgranization);
    public static partial IQueryable<UserOgranizationDto> ToUserOgranizationDtoQueryable(this IQueryable<UserOgranization> userOgranization);
}