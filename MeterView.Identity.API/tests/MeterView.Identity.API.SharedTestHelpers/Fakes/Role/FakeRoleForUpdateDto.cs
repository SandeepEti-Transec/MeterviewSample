namespace MeterView.Identity.API.SharedTestHelpers.Fakes.Role;

using AutoBogus;
using MeterView.Identity.API.Domain.Roles;
using MeterView.Identity.API.Domain.Roles.Dtos;

public sealed class FakeRoleForUpdateDto : AutoFaker<RoleForUpdateDto>
{
    public FakeRoleForUpdateDto()
    {
    }
}