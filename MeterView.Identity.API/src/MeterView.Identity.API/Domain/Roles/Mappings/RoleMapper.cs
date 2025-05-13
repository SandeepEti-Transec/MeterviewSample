namespace MeterView.Identity.API.Domain.Roles.Mappings;

using MeterView.Identity.API.Domain.Roles.Dtos;
using MeterView.Identity.API.Domain.Roles.Models;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class RoleMapper
{
    public static partial RoleForCreation ToRoleForCreation(this RoleForCreationDto roleForCreationDto);
    public static partial RoleForUpdate ToRoleForUpdate(this RoleForUpdateDto roleForUpdateDto);
    public static partial RoleDto ToRoleDto(this Role role);
    public static partial IQueryable<RoleDto> ToRoleDtoQueryable(this IQueryable<Role> role);
}