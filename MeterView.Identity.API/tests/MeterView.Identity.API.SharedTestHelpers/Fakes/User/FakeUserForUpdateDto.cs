namespace MeterView.Identity.API.SharedTestHelpers.Fakes.User;

using AutoBogus;
using MeterView.Identity.API.Domain.Users;
using MeterView.Identity.API.Domain.Users.Dtos;

public sealed class FakeUserForUpdateDto : AutoFaker<UserForUpdateDto>
{
    public FakeUserForUpdateDto()
    {
    }
}