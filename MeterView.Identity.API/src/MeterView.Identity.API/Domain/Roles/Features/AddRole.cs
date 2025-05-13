namespace MeterView.Identity.API.Domain.Roles.Features;

using MeterView.Identity.API.Databases;
using MeterView.Identity.API.Domain.Roles;
using MeterView.Identity.API.Domain.Roles.Dtos;
using MeterView.Identity.API.Domain.Roles.Models;
using MeterView.Identity.API.Services;
using MeterView.Identity.API.Exceptions;
using Mappings;
using MediatR;

public static class AddRole
{
    public sealed record Command(RoleForCreationDto RoleToAdd) : IRequest<RoleDto>;

    public sealed class Handler(IdentityDbContext dbContext)
        : IRequestHandler<Command, RoleDto>
    {
        public async Task<RoleDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var roleToAdd = request.RoleToAdd.ToRoleForCreation();
            var role = Role.Create(roleToAdd);

            await dbContext.Roles.AddAsync(role, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return role.ToRoleDto();
        }
    }
}