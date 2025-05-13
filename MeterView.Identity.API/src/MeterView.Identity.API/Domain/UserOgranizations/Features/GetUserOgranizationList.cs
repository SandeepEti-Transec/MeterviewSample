namespace MeterView.Identity.API.Domain.UserOgranizations.Features;

using MeterView.Identity.API.Domain.UserOgranizations.Dtos;
using MeterView.Identity.API.Databases;
using MeterView.Identity.API.Exceptions;
using MeterView.Identity.API.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetUserOgranizationList
{
    public sealed record Query(UserOgranizationParametersDto QueryParameters) : IRequest<PagedList<UserOgranizationDto>>;

    public sealed class Handler(IdentityDbContext dbContext)
        : IRequestHandler<Query, PagedList<UserOgranizationDto>>
    {
        public async Task<PagedList<UserOgranizationDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = dbContext.UserOgranizations.AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToUserOgranizationDtoQueryable();

            return await PagedList<UserOgranizationDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}