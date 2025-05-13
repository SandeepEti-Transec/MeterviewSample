namespace MeterView.Identity.API.Domain.Users.Features;

using MeterView.Identity.API.Domain.Users;
using MeterView.Identity.API.Domain.Users.Dtos;
using MeterView.Identity.API.Databases;
using MeterView.Identity.API.Services;
using MeterView.Identity.API.Domain.Users.Models;
using MeterView.Identity.API.Exceptions;
using Mappings;
using MediatR;

public static class UpdateUser
{
    public sealed record Command(Guid UserId, UserForUpdateDto UpdatedUserData) : IRequest;

    public sealed class Handler(IdentityDbContext dbContext)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var userToUpdate = await dbContext.Users.GetById(request.UserId, cancellationToken: cancellationToken);
            var userToAdd = request.UpdatedUserData.ToUserForUpdate();
            userToUpdate.Update(userToAdd);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}