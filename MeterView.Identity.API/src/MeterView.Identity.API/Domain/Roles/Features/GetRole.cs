namespace MeterView.Identity.API.Domain.Roles.Features;

using MeterView.Identity.API.Domain.Roles.Dtos;
using MeterView.Identity.API.Databases;
using MeterView.Identity.API.Exceptions;
using Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

public static class GetRole
{
    public sealed record Query(Guid RoleId) : IRequest<RoleDto>;

    public sealed class Handler(IdentityDbContext dbContext)
        : IRequestHandler<Query, RoleDto>
    {
        public async Task<RoleDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await dbContext.Roles
                .AsNoTracking()
                .GetById(request.RoleId, cancellationToken);
            return result.ToRoleDto();
        }
    }
}