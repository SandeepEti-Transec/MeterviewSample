namespace MeterView.Identity.API.Domain.UserRoles.Mappings;

using MeterView.Identity.API.Domain.UserRoles.Dtos;
using MeterView.Identity.API.Domain.UserRoles.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class UserRoleMapper
{
    public static partial UserRoleForCreation ToUserRoleForCreation(this UserRoleForCreationDto userRoleForCreationDto);
    public static partial UserRoleForUpdate ToUserRoleForUpdate(this UserRoleForUpdateDto userRoleForUpdateDto);
    public static partial UserRoleDto ToUserRoleDto(this UserRole userRole);
    public static partial IQueryable<UserRoleDto> ToUserRoleDtoQueryable(this IQueryable<UserRole> userRole);
}