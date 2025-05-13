namespace MeterView.Identity.API.SharedTestHelpers.Fakes.UserRole;

using AutoBogus;
using MeterView.Identity.API.Domain.UserRoles;
using MeterView.Identity.API.Domain.UserRoles.Models;

public sealed class FakeUserRoleForCreation : AutoFaker<UserRoleForCreation>
{
    public FakeUserRoleForCreation()
    {
    }
}