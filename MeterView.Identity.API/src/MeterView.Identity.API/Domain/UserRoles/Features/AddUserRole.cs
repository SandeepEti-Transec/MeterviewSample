namespace MeterView.Identity.API.Domain.UserRoles.Features;

using MeterView.Identity.API.Databases;
using MeterView.Identity.API.Domain.UserRoles;
using MeterView.Identity.API.Domain.UserRoles.Dtos;
using MeterView.Identity.API.Domain.UserRoles.Models;
using MeterView.Identity.API.Services;
using MeterView.Identity.API.Exceptions;
using Mappings;
using MediatR;

public static class AddUserRole
{
    public sealed record Command(UserRoleForCreationDto UserRoleToAdd) : IRequest<UserRoleDto>;

    public sealed class Handler(IdentityDbContext dbContext)
        : IRequestHandler<Command, UserRoleDto>
    {
        public async Task<UserRoleDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var userRoleToAdd = request.UserRoleToAdd.ToUserRoleForCreation();
            var userRole = UserRole.Create(userRoleToAdd);

            await dbContext.UserRoles.AddAsync(userRole, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return userRole.ToUserRoleDto();
        }
    }
}