namespace MeterView.Identity.API.Domain.UserRoles.Features;

using MeterView.Identity.API.Domain.UserRoles.Dtos;
using MeterView.Identity.API.Databases;
using MeterView.Identity.API.Exceptions;
using MeterView.Identity.API.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetUserRoleList
{
    public sealed record Query(UserRoleParametersDto QueryParameters) : IRequest<PagedList<UserRoleDto>>;

    public sealed class Handler(IdentityDbContext dbContext)
        : IRequestHandler<Query, PagedList<UserRoleDto>>
    {
        public async Task<PagedList<UserRoleDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = dbContext.UserRoles.AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToUserRoleDtoQueryable();

            return await PagedList<UserRoleDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}