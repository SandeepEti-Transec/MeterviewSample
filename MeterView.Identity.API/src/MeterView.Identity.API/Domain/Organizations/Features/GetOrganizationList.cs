namespace MeterView.Identity.API.Domain.Organizations.Features;

using MeterView.Identity.API.Domain.Organizations.Dtos;
using MeterView.Identity.API.Databases;
using MeterView.Identity.API.Exceptions;
using MeterView.Identity.API.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetOrganizationList
{
    public sealed record Query(OrganizationParametersDto QueryParameters) : IRequest<PagedList<OrganizationDto>>;

    public sealed class Handler(IdentityDbContext dbContext)
        : IRequestHandler<Query, PagedList<OrganizationDto>>
    {
        public async Task<PagedList<OrganizationDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = dbContext.Organizations.AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToOrganizationDtoQueryable();

            return await PagedList<OrganizationDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}