namespace MeterView.Identity.API.Domain.Roles.Features;

using MeterView.Identity.API.Domain.Roles;
using MeterView.Identity.API.Domain.Roles.Dtos;
using MeterView.Identity.API.Databases;
using MeterView.Identity.API.Services;
using MeterView.Identity.API.Domain.Roles.Models;
using MeterView.Identity.API.Exceptions;
using Mappings;
using MediatR;

public static class UpdateRole
{
    public sealed record Command(Guid RoleId, RoleForUpdateDto UpdatedRoleData) : IRequest;

    public sealed class Handler(IdentityDbContext dbContext)
        : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var roleToUpdate = await dbContext.Roles.GetById(request.RoleId, cancellationToken: cancellationToken);
            var roleToAdd = request.UpdatedRoleData.ToRoleForUpdate();
            roleToUpdate.Update(roleToAdd);

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}