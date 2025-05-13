namespace MeterView.Identity.API.Domain.UserOgranizations.Features;

using MeterView.Identity.API.Domain.UserOgranizations.Dtos;
using MeterView.Identity.API.Databases;
using MeterView.Identity.API.Exceptions;
using Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

public static class GetUserOgranization
{
    public sealed record Query(Guid UserOgranizationId) : IRequest<UserOgranizationDto>;

    public sealed class Handler(IdentityDbContext dbContext)
        : IRequestHandler<Query, UserOgranizationDto>
    {
        public async Task<UserOgranizationDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await dbContext.UserOgranizations
                .AsNoTracking()
                .GetById(request.UserOgranizationId, cancellationToken);
            return result.ToUserOgranizationDto();
        }
    }
}