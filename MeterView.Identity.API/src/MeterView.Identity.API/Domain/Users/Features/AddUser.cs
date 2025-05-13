namespace MeterView.Identity.API.Domain.Users.Features;

using MeterView.Identity.API.Databases;
using MeterView.Identity.API.Domain.Users;
using MeterView.Identity.API.Domain.Users.Dtos;
using MeterView.Identity.API.Domain.Users.Models;
using MeterView.Identity.API.Services;
using MeterView.Identity.API.Exceptions;
using Mappings;
using MediatR;

public static class AddUser
{
    public sealed record Command(UserForCreationDto UserToAdd) : IRequest<UserDto>;

    public sealed class Handler(IdentityDbContext dbContext)
        : IRequestHandler<Command, UserDto>
    {
        public async Task<UserDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var userToAdd = request.UserToAdd.ToUserForCreation();
            var user = User.Create(userToAdd);

            await dbContext.Users.AddAsync(user, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return user.ToUserDto();
        }
    }
}