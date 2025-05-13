namespace MeterView.Support.API.Domain.FeedBacks.Features;

using MeterView.Support.API.Domain.FeedBacks.Dtos;
using MeterView.Support.API.Databases;
using MeterView.Support.API.Exceptions;
using MeterView.Support.API.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetFeedBackList
{
    public sealed record Query(FeedBackParametersDto QueryParameters) : IRequest<PagedList<FeedBackDto>>;

    public sealed class Handler(SupportDbContext dbContext)
        : IRequestHandler<Query, PagedList<FeedBackDto>>
    {
        public async Task<PagedList<FeedBackDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = dbContext.FeedBacks.AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToFeedBackDtoQueryable();

            return await PagedList<FeedBackDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}