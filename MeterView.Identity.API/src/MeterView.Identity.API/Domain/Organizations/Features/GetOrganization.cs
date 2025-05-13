namespace MeterView.Identity.API.Domain.Organizations.Features;

using MeterView.Identity.API.Domain.Organizations.Dtos;
using MeterView.Identity.API.Databases;
using MeterView.Identity.API.Exceptions;
using Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;

public static class GetOrganization
{
    public sealed record Query(Guid OrganizationId) : IRequest<OrganizationDto>;

    public sealed class Handler(IdentityDbContext dbContext)
        : IRequestHandler<Query, OrganizationDto>
    {
        public async Task<OrganizationDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await dbContext.Organizations
                .AsNoTracking()
                .GetById(request.OrganizationId, cancellationToken);
            return result.ToOrganizationDto();
        }
    }
}