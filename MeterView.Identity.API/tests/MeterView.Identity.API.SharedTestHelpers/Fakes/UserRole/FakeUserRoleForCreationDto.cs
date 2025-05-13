namespace MeterView.Identity.API.SharedTestHelpers.Fakes.UserRole;

using AutoBogus;
using MeterView.Identity.API.Domain.UserRoles;
using MeterView.Identity.API.Domain.UserRoles.Dtos;

public sealed class FakeUserRoleForCreationDto : AutoFaker<UserRoleForCreationDto>
{
    public FakeUserRoleForCreationDto()
    {
    }
}