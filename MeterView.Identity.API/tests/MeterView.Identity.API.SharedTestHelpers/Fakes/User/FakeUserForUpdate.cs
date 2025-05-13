namespace MeterView.Identity.API.SharedTestHelpers.Fakes.User;

using AutoBogus;
using MeterView.Identity.API.Domain.Users;
using MeterView.Identity.API.Domain.Users.Models;

public sealed class FakeUserForUpdate : AutoFaker<UserForUpdate>
{
    public FakeUserForUpdate()
    {
    }
}