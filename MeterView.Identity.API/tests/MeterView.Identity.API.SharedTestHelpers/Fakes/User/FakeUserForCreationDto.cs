namespace MeterView.Identity.API.SharedTestHelpers.Fakes.User;

using AutoBogus;
using MeterView.Identity.API.Domain.Users;
using MeterView.Identity.API.Domain.Users.Dtos;

public sealed class FakeUserForCreationDto : AutoFaker<UserForCreationDto>
{
    public FakeUserForCreationDto()
    {
    }
}