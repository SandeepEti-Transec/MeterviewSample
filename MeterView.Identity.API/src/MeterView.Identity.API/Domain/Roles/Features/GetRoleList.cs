namespace MeterView.Identity.API.Domain.Roles.Features;

using MeterView.Identity.API.Domain.Roles.Dtos;
using MeterView.Identity.API.Databases;
using MeterView.Identity.API.Exceptions;
using MeterView.Identity.API.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetRoleList
{
    public sealed record Query(RoleParametersDto QueryParameters) : IRequest<PagedList<RoleDto>>;

    public sealed class Handler(IdentityDbContext dbContext)
        : IRequestHandler<Query, PagedList<RoleDto>>
    {
        public async Task<PagedList<RoleDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = dbContext.Roles.AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToRoleDtoQueryable();

            return await PagedList<RoleDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}