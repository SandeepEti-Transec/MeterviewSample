namespace MeterView.Identity.API.SharedTestHelpers.Fakes.Role;

using AutoBogus;
using MeterView.Identity.API.Domain.Roles;
using MeterView.Identity.API.Domain.Roles.Models;

public sealed class FakeRoleForCreation : AutoFaker<RoleForCreation>
{
    public FakeRoleForCreation()
    {
    }
}