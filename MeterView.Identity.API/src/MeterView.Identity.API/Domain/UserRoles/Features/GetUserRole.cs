namespace MeterView.Identity.API.Domain.UserRoles.Features;

using MeterView.Identity.API.Domain.UserRoles.Dtos;
using MeterView.Identity.API.Databases;
using MeterView.Identity.API.Exceptions;
using Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

public static class GetUserRole
{
    public sealed record Query(Guid UserRoleId) : IRequest<UserRoleDto>;

    public sealed class Handler(IdentityDbContext dbContext)
        : IRequestHandler<Query, UserRoleDto>
    {
        public async Task<UserRoleDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await dbContext.UserRoles
                .AsNoTracking()
                .GetById(request.UserRoleId, cancellationToken);
            return result.ToUserRoleDto();
        }
    }
}