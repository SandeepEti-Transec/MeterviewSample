namespace MeterView.Identity.API.Domain.UserRoles.Features;

using MeterView.Identity.API.Domain.UserRoles;
using MeterView.Identity.API.Domain.UserRoles.Dtos;
using MeterView.Identity.API.Databases;
using MeterView.Identity.API.Services;
using MeterView.Identity.API.Domain.UserRoles.Models;
using MeterView.Identity.API.Exceptions;
using Mappings;
using MediatR;

public static class UpdateUserRole
{
    public sealed record Command(Guid UserRoleId, UserRoleForUpdateDto UpdatedUserRoleData) : IRequest;

    public sealed class Handler(IdentityDbContext dbContext)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var userRoleToUpdate = await dbContext.UserRoles.GetById(request.UserRoleId, cancellationToken: cancellationToken);
            var userRoleToAdd = request.UpdatedUserRoleData.ToUserRoleForUpdate();
            userRoleToUpdate.Update(userRoleToAdd);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}